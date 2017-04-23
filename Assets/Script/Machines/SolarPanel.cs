using System;
using UnityEngine;
using UnityEngine.Assertions;
//using UnityEngine.PlaymodeTests;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class SolarPanel : MonoBehaviour, ISteamHandler
{
	public float nextActionTime = 0.1f;

	private float period = 0.1f;

	public GameObject electricityTarget;

	public GameObject sun;
	[ReadOnly]
	public double efficiency = 0;
	[ReadOnly]
	public float steamLevel = 0;

	public float rotationSpeed = 5f;

	void Update ()
	{
		/*
		 * Rotation handling code
		 */
		double panelRotation = this.transform.eulerAngles.y;
		double sunRotation = sun.transform.eulerAngles.y;

		//this.transform.eulerAngles = new Vector3(0.0f, 360.0f, 0.0f);
		//sun.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

		//Debug.Log ("Sun: " + sunRotation + ". Panel: " + panelRotation);

		// This line is the absolute of the absolute of ....
		efficiency = CalculateEfficiency (sunRotation, panelRotation);
		//Debug.Log ("Solar Panel efficiency: " + efficiency);

		/*
		 * Electricity handling code
		 */
		if (Time.time > nextActionTime ) {
			nextActionTime += period;
			ExecuteEvents.Execute<IElectricityHandler>(electricityTarget, null, (x,y)=>x.ReceiveElectricity(efficiency));
		}
	}

	public void ReceiveSteam()
	{
		Debug.Log ("Solar panel got steam");
		this.transform.Rotate (0, rotationSpeed, 0);
	}

	// Borrowed from: https://stackoverflow.com/questions/7570808/how-do-i-calculate-the-difference-of-two-angle-measures
	private double Distance (double a, double b)
	{
		double phi = Math.Abs (a - b) % 360;
		double distance = phi > 180.0f ? 360.0f - phi : phi;
		return distance;
	}

	private double CalculateEfficiency (double a, double b)
	{
		return Math.Round (Distance (a, b) / 180.0f, 1);
	}

	// How do I run this?!

}
