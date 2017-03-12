using UnityEngine;
using System.Collections;

public class UnlockAchievements : MonoBehaviour {

	private bool isBusUnlocked = false;
	private bool isCompactUnlocked = false;
	private bool isCoupeUnlocked = false;
	private bool isInterceptorUnlocked = false;
	private bool isScooterUnlocked = false;
	private bool isSedanUnlocked = false;
	private bool isCombiUnlocked = false;
	private bool isSportsterUnlocked = false;
	private bool isTaxiUnlocked = false;
	private bool isVanUnlocked = false;

	public int gamesPlayed;

	const string BUS = "BUS"; // Ab 200 Games unlocked, score 1300
	const string COMPACT = "COMPACT"; // Default
	const string COUPE = "COUPE"; // ab 25 Games unlocked, score 1000
	const string INTERCEPTOR = "INTERCEPTOR"; // ab 3 Games Unlocked, score 500
	const string SCOOTER = "SCOOTER"; // bei genau score 2222 unlocked
	const string SEDAN = "SEDAN"; 
	const string COMBI = "COMBI"; // bei 50 games und score 1100
	const string SPORTSTER = "SPORTSTER"; //bei 100 games, score 1500
	const string TAXI = "TAXI"; //Bei crash in ein Taxi unlocked
	const string VAN = "VAN";	//ab 10 Games Unlocked, score 1200


	void Awake() {
		GetUnlockedCars ();
		gamesPlayed = PlayerPrefs.GetInt ("GAMESPLAYED", 0);
		print ("Spiele gespielt: " + gamesPlayed);
		PlayerPrefs.SetInt ("GAMESPLAYED", ++gamesPlayed);
	}
	void Update() {
		if(3 <= gamesPlayed) UnlockInterceptor();
		if (10 <= gamesPlayed) UnlockVan ();
		if (25 <= gamesPlayed) UnlockCoupe ();
		if (50 <= gamesPlayed) UnlockCombi ();
		if (75 <= gamesPlayed) UnlockSedan ();
		if(100 <= gamesPlayed) UnlockSportster();
		if (200 <= gamesPlayed) UnlockBus ();
		//Scooter wird in Scoresystem bei score 2222 unlocked
		//Taxi wird bei Crash unlocked

	}

	void UnlockInterceptor() {
		if (GameObject.Find ("Score").GetComponent<ScoreSystem> ().score >= 500 && isInterceptorUnlocked == false) {
			this.gameObject.GetComponent<SpawnAchievements>().SendMessage("SpawnInterceptor");
			isInterceptorUnlocked = true;
		}
	}

	void UnlockCoupe() {
		if (GameObject.Find ("Score").GetComponent<ScoreSystem> ().score >= 1000 && isCoupeUnlocked == false) {
			this.gameObject.GetComponent<SpawnAchievements>().SendMessage("SpawnCoupe");
			isCoupeUnlocked = true;
		}
	}

	void UnlockSportster() {
		if (GameObject.Find ("Score").GetComponent<ScoreSystem> ().score >= 1500 && isSportsterUnlocked == false) {
			this.gameObject.GetComponent<SpawnAchievements>().SendMessage("SpawnSportster");
			isSportsterUnlocked = true;
		}
	}

	void UnlockBus() {
		if (GameObject.Find ("Score").GetComponent<ScoreSystem> ().score >= 1300 && isBusUnlocked == false) {
			this.gameObject.GetComponent<SpawnAchievements>().SendMessage("SpawnBus");
			isBusUnlocked = true;
		}
	}

	void UnlockVan() {
		if (GameObject.Find ("Score").GetComponent<ScoreSystem> ().score >= 1200 && isVanUnlocked == false) {
			this.gameObject.GetComponent<SpawnAchievements>().SendMessage("SpawnVan");
			isVanUnlocked = true;
		}
	}

	void UnlockCombi() {
		if (GameObject.Find ("Score").GetComponent<ScoreSystem> ().score >= 1100 && isCombiUnlocked == false) {
			this.gameObject.GetComponent<SpawnAchievements>().SendMessage("SpawnCombi");
			isCombiUnlocked = true;
		}
	}

	void UnlockSedan() {
		if (GameObject.Find ("Score").GetComponent<ScoreSystem> ().score >= 900 && isSedanUnlocked == false) {
			this.gameObject.GetComponent<SpawnAchievements>().SendMessage("SpawnSedan");
			isSedanUnlocked = true;
		}
	}


	public void GetUnlockedCars() {
		if (PlayerPrefs.GetInt (BUS, 0) == 1) {isBusUnlocked = true;} else {isBusUnlocked = false;} 
		
		//Compact ist standard und darf nie unlocked sein
		isCompactUnlocked = true;
		
		if (PlayerPrefs.GetInt (COUPE, 0) == 1) {isCoupeUnlocked = true;} else {isCoupeUnlocked = false;}
		if (PlayerPrefs.GetInt (INTERCEPTOR, 0) == 1) {isInterceptorUnlocked = true;} else {isInterceptorUnlocked = false;}
		if (PlayerPrefs.GetInt (SCOOTER, 0) == 1) {isScooterUnlocked = true;} else {isScooterUnlocked = false;}
		if (PlayerPrefs.GetInt (SEDAN, 0) == 1) {isSedanUnlocked = true;} else {isSedanUnlocked = false;}
		if (PlayerPrefs.GetInt (COMBI, 0) == 1) {isCombiUnlocked = true;} else {isCombiUnlocked = false;}
		if (PlayerPrefs.GetInt (SPORTSTER, 0) == 1) {isSportsterUnlocked = true;} else {isSportsterUnlocked = false;}
		if (PlayerPrefs.GetInt (TAXI, 0) == 1) {isTaxiUnlocked = true;} else {isTaxiUnlocked = false;}
		if (PlayerPrefs.GetInt (VAN, 0) == 1) {isVanUnlocked = true;} else {isVanUnlocked = false;}
	}
}
