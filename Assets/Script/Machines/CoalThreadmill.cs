using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class CoalThreadmill : MonoBehaviour, IElectricityHandler
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		//TODO send coal to steam boiler

	}

	public void ReceiveElectricity (double amount)
	{
		Debug.Log ("CoalThreadmill is receiving steam");
		gameObject.BroadcastMessage("UpdateThreadmillSpeed", amount);
	}
}


