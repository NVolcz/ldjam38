using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class SteamBoiler : MonoBehaviour, ICoalHandler
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
			ExecuteEvents.Execute<ISteamHandler>(steamTarget, null, (x,y)=>x.ReceiveSteam());
			Debug.Log ("STEAM!! YEAAH!");
		}
	}

	public void ReceiveCoal() {
		Debug.Log ("Coal RECEIVED!! YEAAH!");
	}
}


