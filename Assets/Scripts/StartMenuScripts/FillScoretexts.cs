using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FillScoretexts : MonoBehaviour {

	public Text highscoreText;
	public Text highscoreText1;
	public Text lastscoreText;
	public Text lastscoreText1;

	void Awake() {
		highscoreText.text = "Highscore: " + PlayerPrefs.GetInt ("HIGHSCORE", 0);
		highscoreText1.text = "Highscore: " + PlayerPrefs.GetInt ("HIGHSCORE", 0);
		lastscoreText.text = "Zuletzt gespielt: " + PlayerPrefs.GetInt ("LASTSCORE", 0);
		lastscoreText1.text = "Zuletzt gespielt: " + PlayerPrefs.GetInt ("LASTSCORE", 0);
	}
}
