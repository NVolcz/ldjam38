using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTempBar : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void UpdateTemperatureBar(int newValue) {
		this.gameObject.GetComponent<Slider> ().value = newValue;
	}
}
