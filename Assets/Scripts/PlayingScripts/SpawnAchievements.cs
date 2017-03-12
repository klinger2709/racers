using UnityEngine;
using System.Collections;

public class SpawnAchievements : MonoBehaviour {

	public GameObject coins; 

	private GameObject[] tracks;
	private GameObject coinContainer;
	private int nextTrack;

	public GameObject bus;
	public GameObject interceptor;
	public GameObject combi;
	public GameObject van;
	//public GameObject taxi;
	public GameObject coupe;
	public GameObject sportster;
	public GameObject sedan;

	void Awake() {
		tracks = new GameObject[gameObject.transform.childCount];
		tracks [0] = GameObject.Find ("Spur1");
		tracks [1] = GameObject.Find ("Spur2");
		tracks [2] = GameObject.Find ("Spur3");
		tracks [3] = GameObject.Find ("Spur4");

		coinContainer = new GameObject ();
		coinContainer.name = "CoinContainer";

		StartCoroutine (SpawnCoins());
	}

	//Default coins
	IEnumerator SpawnCoins() {
		yield return new WaitForSeconds (5);
		nextTrack = Random.Range (0, tracks.Length);
		//Spawn coinArray
		GameObject currentCoins = (GameObject)Instantiate (
			coins, 
			//Get only the x and z pos of the track
			new Vector3(
				tracks[nextTrack].transform.position.x, 
				coins.transform.position.y, 
				tracks[nextTrack].transform.position.z), 
			Quaternion.identity);
		//set Parent
		currentCoins.transform.SetParent (coinContainer.transform);
		//Do the same again
		StartCoroutine (SpawnCoins ());
	}

	void SpawnInterceptor() {
		Instantiate (
			interceptor,
			new Vector3(
				tracks[Random.Range(0, tracks.Length)].transform.position.x,
				interceptor.transform.position.y,
				tracks[0].transform.position.z),
			Quaternion.identity);
	}

	void SpawnSportster() {
		Instantiate (
			sportster, 
			new Vector3(
				tracks[Random.Range(0, tracks.Length)].transform.position.x, 
				sportster.transform.position.y, 
				tracks[0].transform.position.z), 
			Quaternion.identity);
	}

	void SpawnCoupe() {
		Instantiate (
			coupe, 
			new Vector3(
			tracks[Random.Range(0, tracks.Length)].transform.position.x, 
			coupe.transform.position.y, 
			tracks[0].transform.position.z), 
			Quaternion.identity);
	}

	void SpawnBus() {
		Instantiate (
			bus, 
			new Vector3(
			tracks[Random.Range(0, tracks.Length)].transform.position.x, 
			bus.transform.position.y, 
			tracks[0].transform.position.z), 
			Quaternion.identity);
	}

	void SpawnVan() {
		Instantiate (
			van, 
			new Vector3(
			tracks[Random.Range(0, tracks.Length)].transform.position.x, 
			van.transform.position.y, 
			tracks[0].transform.position.z), 
			Quaternion.identity);
	}

	void SpawnCombi() {
		Instantiate (
			combi, 
			new Vector3(
			tracks[Random.Range(0, tracks.Length)].transform.position.x, 
			combi.transform.position.y, 
			tracks[0].transform.position.z), 
			Quaternion.identity);
	}

	void SpawnSedan() {
		Instantiate (
			sedan, 
			new Vector3(
			tracks[Random.Range(0, tracks.Length)].transform.position.x, 
			combi.transform.position.y, 
			tracks[0].transform.position.z), 
			Quaternion.identity);
	}
}
