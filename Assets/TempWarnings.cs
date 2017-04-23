using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWarnings : MonoBehaviour {

	AudioSource[] sfxList = new AudioSource[4];

	void Start () {
		sfxList [0] = this.transform.FindChild ("HighPressure1").GetComponent<AudioSource> ();
		sfxList [1] = this.transform.FindChild ("HighPressure2").GetComponent<AudioSource> ();
		sfxList [2] = this.transform.FindChild ("HighPressure3").GetComponent<AudioSource> ();
		sfxList [3] = this.transform.FindChild ("BoilerExplodes").GetComponent<AudioSource> ();
	}
	
	void Update () {
		
	}

	public void UpdateTemperatureBar(int temp) {
		if (temp < 70) {
			foreach (AudioSource sfx in sfxList) {
				sfx.Stop ();
			}
		} else if (temp >= 70 && temp < 80) {
			sfxList [0].Play ();
		} else if (temp >= 80 && temp < 90) {
			sfxList [1].Play ();
		} else if (temp >= 90 && temp < 100) {
			sfxList [2].Play ();
		} else if (temp >= 100) {
			if (!sfxList [3].isPlaying) {
				sfxList [3].Play ();
			}
		}
	}
}
