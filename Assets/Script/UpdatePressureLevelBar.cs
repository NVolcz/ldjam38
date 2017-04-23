using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePressureLevelBar : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void UpdatePressureBar(int newValue) {
		this.gameObject.GetComponent<Slider> ().value = newValue;
	}
}
