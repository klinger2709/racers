using UnityEngine;
using System.Collections;

public class HighscoreControl : MonoBehaviour {

	public TextMesh names;
	public TextMesh scores;

	const string myURL = "http://dreamlo.com/lb/";
	const string PUBLICCODE = "56b6320d6e51b61b7c0a29cd";
	const string PRIVATECODE = "F4IqwCoQeU2tqlFoz4ZT-wld2Y4yjDokewx4r-unLF0w";
	
	private string[] top10;

	public void HighscoreClicked() {
		PostHighscore (PlayerPrefs.GetString("Username"), PlayerPrefs.GetInt ("HIGHSCORE", 0));
	}

	void GetHighscores() {
		StartCoroutine (GetHighscoresfromServer ());
	}
	

	void PostHighscore(string username, int score) {
		StartCoroutine(PostHighscoretoServer (username, score));
	}

	IEnumerator GetHighscoresfromServer() {
		WWW www = new WWW (myURL + PUBLICCODE + "/pipe/10" );
		yield return www;

		top10 = (www.text).Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		print (top10[0]);
		SetupHighscoreTable ();
	}

	IEnumerator PostHighscoretoServer(string username, int score) {
		if (PlayerPrefs.GetString ("Identifier") == "") {
			generateUserID();
		}
		string id = PlayerPrefs.GetString ("Identifier");
		WWW www = new WWW (myURL + PRIVATECODE + WWW.EscapeURL("/add/" + id + "/" + score + "/90/" + username));
		yield return www;
		print (www.text);
		GetHighscores ();
	}

	void SetupHighscoreTable() {
		int counter = 0;
		names.text = "";
		scores.text = "";
		foreach(string currentScore in top10) {
			string[] tempEntry = currentScore.Split(new char[] {'|'});
			if(tempEntry != null) {
			string username = tempEntry[3];
			string score = tempEntry[1];
			names.text += ++counter + ". " + username + "\n";
				scores.text += score + "\n";
			}
		}
	}

	void generateUserID () {
		string identifier = "";
		string identifiergenerator = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

		for (int i = 0; i < 20; i++)
		{
			identifier += identifiergenerator[Random.Range(0, identifiergenerator.Length)];
		}
		PlayerPrefs.SetString("Identifier", identifier);
	}
}
