using UnityEngine;
using System.Collections;

public class ChooseVehicle : MonoBehaviour {

	public GameObject cursor;
	public GameObject[] vehicles;

	private int pointer;
	private GameObject chosenVehicle;


	void Start() 
	{
		chosenVehicle = FindCurrentChosenVehicle ();
		SetCursorParent ();

	}


	//Change Parent to set Cursor to another position;
	void SetCursorParent() 
	{	
		cursor.transform.SetParent (chosenVehicle.transform);
		cursor.transform.localPosition = new Vector3 (0, cursor.transform.position.y, 0);
	}

	public void ChangeVehicle() 
	{
		for (int i = 0; i < vehicles.Length; i++) {
			if (pointer >= vehicles.Length - 1) {
				pointer = 0;
			} else {
				pointer++;
			}
			if (vehicles [pointer].activeSelf) {
				chosenVehicle = vehicles [pointer];
				break;
			} else {
				print ("Pointer: " + pointer);
			}
		}
		SetCursorParent ();
		print ("Chosenvehicletag: " + chosenVehicle.tag);
		PlayerPrefs.SetString ("CurrentVehicle", chosenVehicle.tag);
	}

	public GameObject FindCurrentChosenVehicle() {
		print ("in FindCUrrent" + PlayerPrefs.GetString ("CurrentVehicle"));
		pointer = 0;
		foreach (GameObject v in vehicles) {
			pointer++;
			if(PlayerPrefs.GetString ("CurrentVehicle") == v.tag) {
				if(v.activeSelf){ 
					print ("Gerade Ausgewählt " + v.gameObject.tag);
					return v; 
				} else {
					return vehicles[1];
					PlayerPrefs.SetInt("CurrentVehicle", 1);
				}
			}
		}
		return vehicles[1];
	}
}
