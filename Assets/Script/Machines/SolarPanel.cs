using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour, ISteamHandler {

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void ReceiveSteam() {
		Debug.Log ("SolarPanel received steam");
	}
}
