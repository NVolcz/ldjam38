using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameTime.startTime = System.DateTime.Now;
	}
}
