using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class SteamBoiler : MonoBehaviour, ICoalHandler, IWaterHandler, IWindHandler
{
	private float nextActionTime = 0.0f;
	public float period = 0.1f; //how often steam will be distributed to router

	private float nextPressureTime = 0.0f;
	public float pressureUpdatePeriod = 1.0f; //how often steam pressure will be increased

	public GameObject steamTarget;

	public int maxWaterLevel = 50; 
	public int maxTemperature = 100;
	public int tempIncreasePerCoal = 1;

	[Range(0,100)]
	public int pressure = 0;

	[Range(0,100)]
	public int temperature = 0;

	[Range(0,100)]
	public int waterLevel = 0;

	public int waterIncrease = 1;
	public int pressureDecrease = 1;
	public float maxPressureIncrease = 10f;

	void Start () {
	}

	void Update () {
		// Decreases pressure and sends steam to router
		if (Time.time > nextActionTime && temperature > 0 && waterLevel > 0) {
			nextActionTime += period;

			pressure -= pressureDecrease;
			if (pressure < 0) {
				pressure = 0;
			}
			ExecuteEvents.Execute<ISteamHandler>(steamTarget, null, (x,y)=>x.ReceiveSteam());
			Debug.Log ("Steam boiler is sending steam to " + steamTarget);
		}

		// Increases pressure by using temp and water
		if (Time.time > nextPressureTime) {
			nextPressureTime += period;
			convertTempAndWaterToSteamPressure ();
		}
	}

	void convertTempAndWaterToSteamPressure() {
		int pressureChange = ((float)temperature / (float)maxTemperature) * maxPressureIncrease;
		pressure += pressureChange;

		waterLevel -= pressureChange;
		if (waterLevel < 0) {
			waterLevel = 0;
		}
		gameObject.BroadcastMessage("UpdateWaterLevelBar", waterLevel);

		temperature -= pressureChange;
		if (temperature < 0) {
			temperature = 0;
		}
		gameObject.BroadcastMessage("UpdateTemperatureBar", temperature);

		gameObject.BroadcastMessage("UpdatePressureBar", pressure);
		Debug.Log ("Increasing pressure by " + pressureChange + ", current pressure is " + pressure);
		if (temperature >= maxTemperature) {
			destroySteamBoiler ();
		}
	}

	public void ReceiveCoal(int amount) {
		Debug.Log ("Coal received by SteamBoiler, amount = " + amount);
		temperature += tempIncreasePerCoal;
		Debug.Log ("current temperature = " + temperature);
		triggerCoalAddedFx (amount);
		gameObject.BroadcastMessage("UpdateTemperatureBar", temperature);
	}

	public void ReceiveWater() {
		Debug.Log ("Water received in SteamBoiler, wooo!");
		if (waterLevel + waterIncrease > maxWaterLevel) { //if water will overflow...
			triggerWaterWasteFx((waterLevel + waterIncrease) - maxWaterLevel);
			waterLevel = maxWaterLevel; //set it to max level and discard the rest
		} else {
			waterLevel += waterIncrease;
		}
		gameObject.BroadcastMessage("UpdateWaterLevelBar", waterLevel);
	}

	public void ReceiveWind() {
		Debug.Log ("Wind received by SteamBoiler!");
	}

	private void triggerWaterWasteFx(int amountOfWaterWasted) {
		gameObject.BroadcastMessage("ActivateWaterWasteFx", amountOfWaterWasted);
	}

	private void triggerCoalAddedFx(int amount) {
		gameObject.BroadcastMessage("ActivateCoalAddFx", amount);
	}

	private void destroySteamBoiler() {

	}
}
