using UnityEngine;
using System.Collections;

public class DetectCollisions : MonoBehaviour {

	const string BUS = "BUS";
	const string COMPACT = "COMPACT";
	const string COUPE = "COUPE";
	const string INTERCEPTOR = "INTERCEPTOR";
	const string SCOOTER = "SCOOTER";
	const string SEDAN = "SEDAN";
	const string COMBI = "COMBI";
	const string SPORTSTER = "SPORTSTER";
	const string TAXI = "TAXI";
	const string VAN = "VAN";

	public bool crashed = false;

	//Wird dem Fahrzeug gegeben damit das Spiel bei einer Collision neu geladen werden kann.
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Vehicle" || col.gameObject.tag == "Sidewalk") {
			StartCoroutine(Crash());
		}

		if (col.gameObject.tag == TAXI) {
			print("Taxi UNLOCKED");
			PlayerPrefs.SetInt(TAXI, 1);
			StartCoroutine(Crash());
		} 
		CheckIfUnlocked (col);
		
	}

	IEnumerator Crash() {
		GameObject.Find ("SoundManager").GetComponent<ManageSounds> ().PlayCrashed();
		Component[] cs = GameObject.Find ("Spawned Vehicles").GetComponentsInChildren<MoveCar> ();
		//stop everything on crash
		foreach (Component c in cs) {
			Destroy(c); 
		}
		Destroy (gameObject.GetComponentInParent<Accelerate> ());
		Destroy (gameObject.GetComponentInParent<Control>());
		crashed = true;
		yield return new WaitForSeconds (1);
		EndGame ();

	}


	void EndGame() {
		Application.LoadLevel ("StartMenu");

		//Letzten, sowie Highscore speichern
		ScoreSystem sc = GameObject.Find ("Score").GetComponent<ScoreSystem> ();
		sc.CheckHighscore ();
	}


	void CheckIfUnlocked(Collision col) {
		if (col.gameObject.tag == INTERCEPTOR) {
			print("Interceptor UNLOCKED");
			Destroy (col.gameObject);
			PlayerPrefs.SetInt(INTERCEPTOR, 1);
		} 
		
		if (col.gameObject.tag == "SUPERSPORT") {
			print("Supersport UNLOCKED");
			Destroy (col.gameObject);
			PlayerPrefs.SetInt(SPORTSTER, 1);
		} 
		
		if (col.gameObject.tag == COUPE) {
			print("Coupe UNLOCKED");
			Destroy (col.gameObject);
			PlayerPrefs.SetInt(COUPE, 1);
		} 
		
		if (col.gameObject.tag == BUS) {
			print("Bus UNLOCKED");
			Destroy (col.gameObject);
			PlayerPrefs.SetInt(BUS, 1);
		} 
		
		if (col.gameObject.tag == VAN) {
			print("Van UNLOCKED");
			PlayerPrefs.SetInt(VAN, 1);
			Destroy (col.gameObject);
		} 
		
		if (col.gameObject.tag == COMBI) {
			print("Combi UNLOCKED");
			PlayerPrefs.SetInt(COMBI, 1);
			Destroy (col.gameObject);
		} 

		if (col.gameObject.tag == SEDAN) {
			print("Sedan UNLOCKED");
			PlayerPrefs.SetInt(SEDAN, 1);
			Destroy (col.gameObject);
		} 
	}
}
