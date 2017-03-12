using UnityEngine;
using System.Collections;

public class SpawnCar : MonoBehaviour {

	public GameObject[] drivingCars;

	private GameObject[] tracks;
	private GameObject vehicles;

	void Awake () {
		tracks = new GameObject[gameObject.transform.childCount];
		tracks [0] = GameObject.Find ("Spur1");
		tracks [1] = GameObject.Find ("Spur2");
		tracks [2] = GameObject.Find ("Spur3");
		tracks [3] = GameObject.Find ("Spur4");

		vehicles = new GameObject ();
		vehicles.name = "Spawned Vehicles";
	}

	void Start() {
		StartCoroutine (SpawnNewCar());
	}
	
	IEnumerator SpawnNewCar() {
		yield return new WaitForSeconds (Random.Range(0.5f, 2f));
		GameObject currentCar = (GameObject) Instantiate(
			drivingCars[Random.Range(0, drivingCars.Length)], 
			tracks[Random.Range(0, tracks.Length)].transform.position, 
			Quaternion.identity);
		currentCar.AddComponent<RemoveTireRigidbody> ();
		currentCar.AddComponent<MoveCar> ();
		currentCar.transform.SetParent (vehicles.transform);
		if (currentCar.name == "Taxi_1A(Clone)") {
		} else {
			currentCar.tag = "Vehicle";
		}
		StartCoroutine (SpawnNewCar ());
	}
}
