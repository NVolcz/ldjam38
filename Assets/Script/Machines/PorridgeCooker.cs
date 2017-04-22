using System;
using UnityEngine;


/*
 * This is actually a pressure cooker for porridge...
 */
public class PorridgeCooker : MonoBehaviour, ISteamHandler
{
	[ReadOnly]
	public int pressure = 0;

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void ReceiveSteam()
	{
		pressure++;
		Debug.Log ("Porridge cooker is receiving steam");
	}
}