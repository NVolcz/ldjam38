using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateEfficencyBar : MonoBehaviour {

	public GameObject target; 
	private SolarPanel panal; 

	// Use this for initialization
	void Start () {
		panal = target.GetComponent<SolarPanel> ();

	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Slider> ().value = (float)panal.efficiency;
	}
}
