using UnityEngine;
using System.Collections;

public class CoinCollector : MonoBehaviour {

	public int coinValue = 5000;
	GameObject Score;

	void Start() {
		Score = GameObject.Find ("Score");
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "Fahrzeug") {
			print ("coin selected");
			Score.GetComponent<ScoreSystem>().SendMessage("AddToScore", coinValue, SendMessageOptions.RequireReceiver);
			GameObject.Find ("SoundManager").GetComponent<ManageSounds> ().PlayCoinSound();
			Destroy(gameObject);
		}
	}
}
