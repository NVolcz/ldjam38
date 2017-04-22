using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class SteamBoiler : MonoBehaviour, IResourceEventHandler
{
	private float nextActionTime = 0.0f;
	public float period = 0.1f;
	public GameObject steamTarget;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextActionTime ) {
			nextActionTime += period;
			ExecuteEvents.Execute<IResourceEventHandler>(steamTarget, null, (x,y)=>x.Receive());
			Debug.Log ("STEAM!! YEAAH!");
		}
	}

	public void Receive() {
		Debug.Log ("Coal RECEIVED!! YEAAH!");
	}
}


