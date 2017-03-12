using UnityEngine;
using System.Collections;

public class Accelerate : MonoBehaviour {

	public float speed;
	public float difficulty;

	private int currentVehicle;

	void Awake() {
		currentVehicle = GameObject.Find ("Car").GetComponent<LoadCurrentVehicle> ().chosenVehicleNr;
		difficulty = 1.5f;
		StartCoroutine (ScaleDifficulty ());
		//if Sportster, game starts faster
		if (currentVehicle == 7) {
			difficulty = 2;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * speed * difficulty);
	}

	IEnumerator ScaleDifficulty() {
		yield return new WaitForSeconds (0.2f);
		difficulty += 0.01f;
		//if sportster maxSpeed is higher
		if (currentVehicle != 7) {
			if (difficulty <= 6.0f) { 
				StartCoroutine (ScaleDifficulty ());
			}
		} else {
			if (difficulty <= 7.0f) { 
				StartCoroutine (ScaleDifficulty ());
			}
		}
	}
}
