using UnityEngine;
using System.Collections;

public class RemoveTireRigidbody : MonoBehaviour {

	// Use this for initialization
	void Awake () {

		foreach (Rigidbody r in gameObject.GetComponentsInChildren<Rigidbody> ()) {
			Destroy(r.gameObject.GetComponent<WheelCollider>());
			Destroy(r);
		}

	}
}
