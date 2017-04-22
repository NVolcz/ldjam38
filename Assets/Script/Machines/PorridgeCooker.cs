using System;
using UnityEngine;


/*
 * This is actually a pressure cooker for porridge...
 */
public class PorridgeCooker : MonoBehaviour, ISteamHandler
{
	[ReadOnly]
	public int pressure = 0;
	private float lastActiveTime = 0.0f;
	private AudioSource sfx;

	void Start () {
		sfx = this.gameObject.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		if (lastActiveTime >= Time.fixedTime) { // if has received steam in the last 10 seconds
			if (!sfx.isPlaying) {
				sfx.Play ();
			}
		} else {
			sfx.Stop ();
		}
	}

	public void ReceiveSteam()
	{
		lastActiveTime = Time.fixedTime + 10f;
		Debug.Log ("Porridge cooker is receiving steam");
	}
}