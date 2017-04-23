using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoalMover : MonoBehaviour {

	private Vector3 start;
	private Vector3 end;
	private Transform coalPiece;
	private float fraction = 0f;

	public float speed = 0.1f;
	public GameObject coalTarget;

	void Start () {
		start = this.transform.FindChild ("StartPoint").GetComponent<Transform> ().position;
		end = this.transform.FindChild ("EndPoint").GetComponent<Transform> ().position;
		coalPiece = this.transform.FindChild ("CoalPiece1").GetComponent<Transform>();
	}
	
	void Update () {
		if (fraction < 1) {
			fraction += Time.deltaTime * speed;
			coalPiece.position = Vector3.Lerp(start, end, fraction);
		}
		if (fraction >= 1) {
			ExecuteEvents.Execute<ICoalHandler> (coalTarget, null, (x, y) => x.ReceiveCoal (1));
			fraction = 0f;
		}
	}

	public void UpdateThreadmillSpeed(double amount) {
		speed = (float)amount;
	}
}
