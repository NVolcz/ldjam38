using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Router : MonoBehaviour, ISteamHandler
{

	public List<GameObject> steamTarget = new List<GameObject> (1);
	private int current;

	// Use this for initialization
	void Start ()
	{
		current = 0;
		Debug.Log ("Router is set to " + steamTarget[current]);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ReceiveSteam ()
	{
		Debug.Log ("Router is sending steam to " + steamTarget [current]);
		ExecuteEvents.Execute<ISteamHandler> (steamTarget [current], null, (x, y) => x.ReceiveSteam ());
	}

	public void CycleTarget ()
	{
		current++;
		if (current == steamTarget.Count) {
			current = 0;
		}
		this.gameObject.GetComponents<AudioSource> ()[current].Play();
		Debug.Log ("CycleTarget called, current = " + current + " (" + steamTarget [current] + ")");
	}
}
