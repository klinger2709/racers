using UnityEngine;
using System.Collections;

public class SetupUnlockedCars : MonoBehaviour {

	public GameObject[] vehicles;

	public bool isBusUnlocked = false;
	public bool isCompactUnlocked = false;
	public bool isCoupeUnlocked = false;
	public bool isInterceptorUnlocked = false;
	public bool isScooterUnlocked = false;
	public bool isSedanUnlocked = false;
	public bool isCombiUnlocked = false;
	public bool isSportsterUnlocked = false;
	public bool isTaxiUnlocked = false;
	public bool isVanUnlocked = false;

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

	public void Awake() {
		GetUnlockedCars();
		SetupCars ();
	}
	
	public void LockAllCars() {
		PlayerPrefs.SetInt (BUS, 0);
		PlayerPrefs.SetInt (COMPACT, 0);
		PlayerPrefs.SetInt (COUPE, 0);
		PlayerPrefs.SetInt (INTERCEPTOR, 0);
		PlayerPrefs.SetInt (SCOOTER, 0);
		PlayerPrefs.SetInt (SEDAN, 0);
		PlayerPrefs.SetInt (COMBI, 0);
		PlayerPrefs.SetInt (SPORTSTER, 0);
		PlayerPrefs.SetInt (TAXI, 0);
		PlayerPrefs.SetInt (VAN, 0);
		print ("Locked all achievements");

		PlayerPrefs.SetInt ("HIGHSCORE", 0);
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

	public void SetupCars() {
		vehicles [0].SetActive (isBusUnlocked);
		vehicles [1].SetActive (isCompactUnlocked);
		vehicles [2].SetActive (isCoupeUnlocked);
		vehicles [3].SetActive (isInterceptorUnlocked);
		vehicles [4].SetActive (isScooterUnlocked);
		vehicles [5].SetActive (isSedanUnlocked);
		vehicles [6].SetActive (isCombiUnlocked);
		vehicles [7].SetActive (isSportsterUnlocked);
		vehicles [8].SetActive (isTaxiUnlocked);
		vehicles [9].SetActive (isVanUnlocked);
	}
}
