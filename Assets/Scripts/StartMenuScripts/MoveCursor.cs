using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour {

	public float directionChangeTime = 1;
	public float speed = 10;

	private float deltaTime;
	bool isUp = true;

	void Update () {
		if (deltaTime > 0) {
			if(isUp) {
				transform.Translate (Vector3.up * Time.deltaTime * speed);
			} else {
				transform.Translate (Vector3.down * Time.deltaTime * speed);			
			}
			deltaTime -= Time.deltaTime;
		} else {
			deltaTime = directionChangeTime;
			isUp = !isUp;
		}
	}

}
