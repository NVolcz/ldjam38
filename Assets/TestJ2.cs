using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.Events;


public class TestJ2 : MonoBehaviour  {
	public class MachineEvent : UnityEvent<bool> {}

	public MachineEvent Machin = new MachineEvent ();
	public UnityEvent OnActive = new UnityEvent ();

	public bool IsOn;

	void OnEnable()
	{
		var count =
			Machin.GetPersistentEventCount ()
			+ OnActive.GetPersistentEventCount ();
		if (count == 0)
		{
			Debug.Log ("No events atatched");
		}
	}



	//public class MachineEvent : Unity
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (IsOn)
		{
			OnActive.Invoke ();
		}
		
	}
}
