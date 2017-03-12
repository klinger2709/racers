using UnityEngine;
using System.Collections;

public class LoadCurrentVehicle : MonoBehaviour {

	public string chosenVehicle;
	public int chosenVehicleNr;
	public GameObject[] vehicles;

	const int bus = 0;
	const int compact = 1;
	const int coupe = 2;
	const int intercepter = 3;
	const int scooter = 4;
	const int sedan = 5;
	const int combi = 6;
	const int sportster = 7;
	const int taxi = 8;
	const int van = 9;

	private GameObject vehicle;

	private string[] vehiclenames = {
		"BUS",
		"COMPACT",
		"COUPE",
		"INTERCEPTOR",
		"SCOOTER",
		"SEDAN",
		"COMBI",
		"SPORTSTER",
		"TAXI",
		"VAN"
	};

	void Awake() {
		chosenVehicle = PlayerPrefs.GetString ("CurrentVehicle", "COMPACT");
		//remove child
		Destroy (gameObject.transform.FindChild("Supersport_1A").gameObject);
		//add one new child
		vehicle = (GameObject) Instantiate (GetCurrentVehicle(), transform.position, Quaternion.identity);
		vehicle.name = "Fahrzeug";
		vehicle.AddComponent<DetectCollisions> ();
		vehicle.AddComponent<RemoveTireRigidbody> ();
		vehicle.transform.SetParent (gameObject.transform);
	}	

	void Start() {
		//Add rigidbody to detect collision
		Rigidbody vehiclesRb = vehicle.AddComponent<Rigidbody> ();
		vehiclesRb.useGravity = false;
		vehiclesRb.constraints = RigidbodyConstraints.FreezeAll;
	}

	GameObject GetCurrentVehicle() {
		if (chosenVehicle == "SUPERSPORT") chosenVehicle = vehiclenames [7];
		for (int i = 0; i < vehiclenames.Length; i++) {
			if(vehiclenames[i] == chosenVehicle) {
				chosenVehicleNr = i;
				return vehicles[i];
			}
		}
		return null;
	}
}
