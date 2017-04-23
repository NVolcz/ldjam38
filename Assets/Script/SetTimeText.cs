using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTimeText : MonoBehaviour {
	public GameObject gameObject;
	private Text text;
	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		string text2 = text.text;
		text2 = text2.Replace("${NUMBER_OF_SECONDS}", GameTime.getTimeSurvived().ToString());
		text.text = text2;
	}
}
