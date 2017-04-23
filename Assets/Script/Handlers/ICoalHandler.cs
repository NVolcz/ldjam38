using System;
using UnityEngine.EventSystems;


public interface ICoalHandler : IEventSystemHandler
{
	void ReceiveCoal(int amount);
}


