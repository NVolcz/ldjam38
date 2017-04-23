using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameTime : MonoBehaviour {
	public static DateTime startTime = DateTime.Now;
	public static DateTime endTime = DateTime.Now;
	public static double getTimeSurvived() {
		return (endTime - startTime).TotalMilliseconds / 1000.0;
	}
}