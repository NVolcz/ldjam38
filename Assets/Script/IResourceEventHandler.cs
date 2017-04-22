using System;
using UnityEngine.EventSystems;

public interface IResourceEventHandler : IEventSystemHandler
{
	void Receive ();
}

