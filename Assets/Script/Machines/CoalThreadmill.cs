using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class CoalThreadmill : MonoBehaviour, ISteamHandler
{
	public GameObject coalTarget;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void ReceiveSteam ()
	{
		Debug.Log ("CoalThreadmill is receiving steam");
		ExecuteEvents.Execute<ISteamHandler> (coalTarget, null, (x, y) => x.ReceiveSteam ());
	}
}


