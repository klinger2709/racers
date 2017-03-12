using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
public class SetUsername : MonoBehaviour {

	void Awake() {
		gameObject.GetComponent<InputField> ().text = 
			gameObject.GetComponent<InputField> ().text = Regex.Replace(PlayerPrefs.GetString ("Username", "Neuer Spieler"), @"[^a-zA-Z0-9 ]", "");
	}

	public void SetUser() {
		PlayerPrefs.SetString ("Username", Regex.Replace(gameObject.GetComponent<InputField> ().text, @"[^a-zA-Z0-9]", ""));
	}
}
