using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class SteamBoiler : MonoBehaviour, ICoalHandler, IWaterHandler
{
	private float nextActionTime = 0.0f;
	public float period = 0.1f;
	public GameObject steamTarget;
	[Range(0,100)]
	public int pressure = 0;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextActionTime ) {
			nextActionTime += period;
			ExecuteEvents.Execute<ISteamHandler>(steamTarget, null, (x,y)=>x.ReceiveSteam());
			Debug.Log ("Steam boiler is sending steam to " + steamTarget);
		}
	}

	public void ReceiveCoal() {
		Debug.Log ("Coal RECEIVED by SteamBoiler!! YEAAH!");
	}

	public void ReceiveWater() {
		Debug.Log ("Water received in SteamBoiler, wooo!");
	}
}


