using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IndustrialFan : MonoBehaviour, ISteamHandler {

	public GameObject windTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReceiveSteam() {
		Debug.Log ("Industrial fan is sending wind to " + windTarget);
		ExecuteEvents.Execute<IWindHandler>(windTarget, null, (x,y)=>x.ReceiveWind());
	}
}
