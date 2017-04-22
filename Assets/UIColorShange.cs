using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColorShange : MonoBehaviour {

	public GameObject target;
	private Image image; 
	private Slider slider;
	private float valueMax;
	private float valueMin;

	// Use this for initialization
	void Start () {
		image = target.GetComponent<Image> ();
		slider = GetComponent<Slider> ();
		getMaxMinNormalised();

	}
	
	// Update is called once per frame
	void Update () {
		var color = new Color (slider.value/valueMax, 1 - slider.value/valueMax, 1 - slider.value/valueMax);
		image.color = color;
	}

	void getMaxMinNormalised()
	{
		valueMax = slider.maxValue;
		valueMin = slider.minValue;
	}
}
