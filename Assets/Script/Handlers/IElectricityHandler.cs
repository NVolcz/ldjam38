using System;
using UnityEngine.EventSystems;


public interface IElectricityHandler : IEventSystemHandler
{
	void ReceiveElectricity(double amount);
}


