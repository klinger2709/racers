using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

	public int score;
	public float scoreMultiplikator;

	public  Text scoreText;
	public 	Text scoreTextShadow;
	const string HIGHSCORE = "HIGHSCORE";
	const string LASTSCORE = "LASTSCORE";


	void Awake() {
		//GUITexts finden
		

		//Scorevariation bei verschiedenen Fahrzeugen
		string currentVehicle = PlayerPrefs.GetString ("CurrentVehicle", "COMPACT");

		switch (currentVehicle) {
			case "BUS": 		scoreMultiplikator = 2f; break; // Bus 
			case "SUPERSPORT": 	scoreMultiplikator = 2f; break; // Sportster
			case "SCOOTER": 	scoreMultiplikator = 0.5f; break;
			default: 			scoreMultiplikator = 1f; break;
		} 
		print ("current Vehicle: " + currentVehicle + scoreMultiplikator);

		StartCoroutine (IncrementHighscore());
	}

	IEnumerator IncrementHighscore() {
		yield return new WaitForSeconds (0.2f / scoreMultiplikator);
		score += (1);
		SetScoreText ();
		if (!GameObject.Find ("Fahrzeug").GetComponent<DetectCollisions> ().crashed) {
			StartCoroutine (IncrementHighscore ());
		}
	}

	void SetScoreText() {
		scoreText.text = "Score: " + score;
		scoreTextShadow.text = "Score: " + score;
	}

	public bool CheckHighscore() {
		//Save last score
		PlayerPrefs.SetInt (LASTSCORE, score);
		if (score == 2222) { //Wenn der Score 2222 erreicht wird Scooter unlocken
			PlayerPrefs.SetInt("SCOOTER", 1);
		}

		//CheckHighscore
		int highscore = PlayerPrefs.GetInt (HIGHSCORE, 0);
		if (score > highscore) {
			PlayerPrefs.SetInt(HIGHSCORE, score);
			return true;
		}
		return false;
	}

	void AddToScore(int amount) {
		score += amount;
	}
}
