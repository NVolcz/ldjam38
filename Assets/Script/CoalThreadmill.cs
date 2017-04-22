using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class CoalThreadmill : MonoBehaviour, IResourceEventHandler
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

	public void Receive ()
	{
		ExecuteEvents.Execute<IResourceEventHandler> (coalTarget, null, (x, y) => x.Receive ());
	}
}


