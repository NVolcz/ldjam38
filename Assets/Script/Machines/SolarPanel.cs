using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.PlaymodeTests;


public class SolarPanel : MonoBehaviour
{
	public GameObject sun;
	public double efficiency = 0;

	void Update ()
	{
		double panelRotation = this.transform.eulerAngles.y;
		double sunRotation = sun.transform.eulerAngles.y;

		//this.transform.eulerAngles = new Vector3(0.0f, 360.0f, 0.0f);
		//sun.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

		//Debug.Log ("Sun: " + sunRotation + ". Panel: " + panelRotation);

		// This line is the absolute of the absolute of ....
		efficiency = CalculateEfficiency(sunRotation, panelRotation);
		//Debug.Log ("Solar Panel efficiency: " + efficiency);
	}

	// Borrowed from: https://stackoverflow.com/questions/7570808/how-do-i-calculate-the-difference-of-two-angle-measures
	private double Distance(double a, double b)
	{
		double phi = Math.Abs(a - b) % 360;
		double distance = phi > 180.0f ? 360.0f - phi : phi;
		return distance;
	}

	private double CalculateEfficiency(double a, double b)
	{
		return Math.Round (Distance (a, b) / 180.0f, 1);
	}

	// How do I run this?!
	[Test]
	public void testEfficiency() {
		// If the sun and panel are pointing in the same direction then 0 efficiency
		Assert.AreEqual(CalculateEfficiency(360.0f, 360.0f), 0.0f);
		Assert.AreEqual(CalculateEfficiency(360.0f, 0.0f), 0.0f);

		// If the sun and panel are pointing at each other then maximal efficiency
		Assert.AreEqual(CalculateEfficiency(180.0f, 360.0f), 1.0f);
	}
}


