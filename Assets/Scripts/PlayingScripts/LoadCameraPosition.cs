using UnityEngine;
using System.Collections;

public class LoadCameraPosition : MonoBehaviour {

	void Awake() {
		if(PlayerPrefs.GetString("CurrentVehicle", "COMPACT") == "BUS") {
			Camera.main.transform.localPosition = new Vector3(0, 14.8f, -12f);
		}
	}
}
