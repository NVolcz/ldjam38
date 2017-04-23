using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WaterTower : MonoBehaviour
{

	public bool isValveOpen = false;
	public float period = 0.1f;
	public GameObject waterTarget;

	private float nextActionTime = 0.0f;

	private AudioSource sfx;
	private float nextSfxTime = 0f;
	private const float sfxPeriod = 5f;

	// Use this for initialization
	void Start ()
	{
		sfx = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isValveOpen) {
			if (Time.time > nextActionTime) {
				nextActionTime += period;
				ExecuteEvents.Execute<IWaterHandler>(waterTarget, null, (x,y)=>x.ReceiveWater());
				Debug.Log ("Water tower sending water to boiler");

				if (Time.time > nextSfxTime) {
					nextSfxTime += sfxPeriod;
					sfx.Play ();
				}
			}
		}
	}

	public void OpenValve() {
		isValveOpen = !isValveOpen;
		Debug.Log ("Water tower valve is " + (isValveOpen ? "open" : "closed"));
	}
}

