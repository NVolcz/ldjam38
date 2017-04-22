using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IndustrialFan : MonoBehaviour, ISteamHandler {

	public GameObject windTarget;
	private float lastActiveTime = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (lastActiveTime >= Time.fixedTime) { // if has received steam in the last 10 seconds
			//ExecuteEvents.Execute<IWindHandler>(windTarget, null, (x,y)=>x.ReceiveWind());
		}
	}

	public void ReceiveSteam() {
		Debug.Log ("Industrial fan is receiving wind");
		lastActiveTime = Time.fixedTime + 10f;
	}
}
