using UnityEngine;
using System.Collections;

public class Cheats : MonoBehaviour {

	const string BUS = "BUS";
	const string COMPACT = "COMPACT"; 
	const string COUPE = "COUPE";
	const string INTERCEPTOR = "INTERCEPTOR"; 
	const string SCOOTER = "SCOOTER"; 
	const string COMBI = "COMBI"; 
	const string SPORTSTER = "SPORTSTER"; 
	const string TAXI = "TAXI";
	const string VAN = "VAN";

	void Awake() {
		if (PlayerPrefs.GetString ("Username", "") == "Scooter") {
			PlayerPrefs.SetInt("SCOOTER", 1);
		}

		if (PlayerPrefs.GetString ("Username", "") == "Bus") {
			PlayerPrefs.SetInt("BUS", 1);
		}

		if (PlayerPrefs.GetString ("Username", "") == "Unlockall") {
			PlayerPrefs.SetInt(BUS, 1);
			PlayerPrefs.SetInt(COMPACT, 1);
			PlayerPrefs.SetInt(COUPE, 1);
			PlayerPrefs.SetInt(INTERCEPTOR, 1);
			PlayerPrefs.SetInt(COMBI, 1);
			PlayerPrefs.SetInt(SPORTSTER, 1);
			PlayerPrefs.SetInt(TAXI, 1);
			PlayerPrefs.SetInt(VAN, 1);

		}
	}
}
