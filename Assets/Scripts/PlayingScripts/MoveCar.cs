using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour {

	public float speed = 10;

	// Use this for initialization
	void Awake () {
		//Turn vehicle if it is below or equal the position of track 2
		if (transform.position.x <= GameObject.Find ("Spur2").transform.position.x) {
			transform.Rotate (Vector3.up * 180);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}
}
