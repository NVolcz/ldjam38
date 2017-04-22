using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Router : MonoBehaviour, ISteamHandler {

	public List<GameObject> steamTarget = new List<GameObject> (1);
	private GameObject current;

	// Use this for initialization
	void Start () {
		// TODO: Make this player controllable

		current = steamTarget[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void ReceiveSteam() {
		ExecuteEvents.Execute<ISteamHandler>(current, null, (x,y)=>x.ReceiveSteam());
	}
}
