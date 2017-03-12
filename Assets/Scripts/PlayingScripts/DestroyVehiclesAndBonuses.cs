using UnityEngine;
using System.Collections;

public class DestroyVehiclesAndBonuses : MonoBehaviour {

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Vehicle" || col.gameObject.tag == "TAXI") {
			Destroy(col.gameObject);
		}
	}		
}
