using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WaterTower : MonoBehaviour
{

	public bool isValveOpen = false;
	public float period = 0.1f;
	public GameObject waterTarget;

	private float nextActionTime = 0.0f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isValveOpen) {
			if (Time.time > nextActionTime) {
				nextActionTime += period;
				ExecuteEvents.Execute<IWaterHandler>(waterTarget, null, (x,y)=>x.ReceiveWater());
				Debug.Log ("Water tower sending water to boiler");
			}
		}
	}

	public void OpenValve() {
		isValveOpen = !isValveOpen;
		Debug.Log ("Water tower valve is " + (isValveOpen ? "open" : "closed"));
	}
}

