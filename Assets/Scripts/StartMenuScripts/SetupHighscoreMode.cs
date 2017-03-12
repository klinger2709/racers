using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetupHighscoreMode : MonoBehaviour {

	public Button startButton;
	public Button HighscoreButton;
	public Button fahrzeugWechselnButton;
	public Button zurueckButton;

	public GameObject whiteboard;

	void Awake() {
		zurueckButton.gameObject.SetActive (false);
	}

	public void SetUpHighscore() {
		ToggleButtons (false);
		GameObject.Find ("CameraMover").GetComponent<Animator>().SetBool("ShowHighscore", true);
	}

	public void CancelHighscore() {
		ToggleButtons (true);
		GameObject.Find ("CameraMover").GetComponent<Animator>().SetBool("ShowHighscore", false);
	}

	void ToggleButtons(bool trigger) {
		//Aktiv wenn highscoremode aus
		startButton.gameObject.SetActive (trigger);
		HighscoreButton.gameObject.SetActive (trigger);
		fahrzeugWechselnButton.gameObject.SetActive (trigger);

		//Aktiv wenn highscoremode ein
		zurueckButton.gameObject.SetActive (!trigger);
		whiteboard.gameObject.SetActive (!trigger);
	}
}
