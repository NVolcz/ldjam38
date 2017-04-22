using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColorShange : MonoBehaviour {

	public GameObject target;
	public Image image; 
	private Slider slider;
	// Use this for initialization
	void Start () {
		image = target.GetComponent<Image> ();
		slider = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		var color = new Color (slider.value, 1 - slider.value, 1 - slider.value);
		image.color = color;
	}
}
