using System;
using UnityEngine;
using UnityEngine.Events;


public class GenericResourceHandler : MonoBehaviour, ISteamHandler, IWaterHandler
{
	public float nextActionTime = 0.1f;
	private float period = 0;

	public UnityEvent onMaxLevel;

	public float maxLevel = 20.0f;

	[ReadOnly]
	public float level = 0;

	public float usage;

	public UnityEvent onUsage;

	void Update ()
	{
		if (level > usage) {
			onUsage.Invoke ();
			level = level - usage < 0 ? 0 : level - usage;
		}
	}

	public void Receive ()
	{
		if (level < maxLevel) {
			level += 10.0f;
		} else {
			onMaxLevel.Invoke ();
		}
	}

	public void ReceiveSteam ()
	{
		Receive ();
	}


	public void ReceiveCoal ()
	{
		Receive ();
	}

	public void ReceiveWater ()
	{
		Receive ();
	}
}


