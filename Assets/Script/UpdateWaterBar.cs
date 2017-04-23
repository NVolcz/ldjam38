using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWaterBar : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void UpdateWaterLevelBar(int newValue) {
		this.gameObject.GetComponent<Slider> ().value = newValue;
	}
}
