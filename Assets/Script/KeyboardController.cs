using System;
using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class KeyboardController : MonoBehaviour
{
	public List<UnityEvent> controllables = new List<UnityEvent> ();
	public List<KeyCode> keys = new List<KeyCode> {
		KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z
	};

	void Start ()
	{
		
		if (!Debug.isDebugBuild) {
			System.Random rnd = new System.Random ();
			keys = keys.OrderBy (r => rnd.Next ()).ToList ();
		}

		Debug.Log (keys[0]);
	}

	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < controllables.Count; i++) {
			if (Input.GetKeyDown (keys [i])) {
				controllables [i].Invoke ();
			}
		}
	}
}


