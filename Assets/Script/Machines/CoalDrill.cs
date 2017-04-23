using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CoalDrill : MonoBehaviour, IElectricityHandler
{
	public float nextActionTime = 0.1f;

	private float period = 0;

	public float electricityLevel = 0.01f;

	public UnityEvent onMaxElectricityLevel;

	public float maxElectricityLevel = 20.0f;

	public GameObject electricityTarget;

	[ReadOnly]
	public double efficiency = 0;
	[ReadOnly]
	public float steamLevel = 0;

	void Update()
	{		
		if (Time.time > nextActionTime ) {
			nextActionTime += period;
			ExecuteEvents.Execute<ICoalHandler>(electricityTarget, null, (x,y)=>x.ReceiveCoal());
		}
	}

	public void ReceiveElectricity()
	{
		if (steamLevel < maxElectricityLevel) {
			steamLevel += 10.0f;
		} else {
			onMaxElectricityLevel.Invoke ();
		}
	}
}
