using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float controlspeed;	

	private GameObject car;

	public float currentSpeed;
	public float maxSpeed = 3f; 

	private float nonRotatingTimer = 0.1f;
	private float currentRotatingTimer;
	private float rotatingTo;


	void Start() {
		//Get Car
		car = GameObject.Find ("Car");

		Application.targetFrameRate = 40;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

	}

	void Update () {
		//Move to sides on Computer
		/*if (Input.GetAxis ("Horizontal") != 0) {
			transform.Translate (Vector3.right * Input.GetAxis ("Horizontal") * (controlspeed / 5));

			car.transform.rotation = Quaternion.Lerp (Quaternion.identity, new Quaternion (
				car.transform.rotation.x, 
				car.transform.rotation.y + (Input.GetAxis ("Horizontal")), 
				car.transform.rotation.z, 
				car.transform.rotation.w), Time.deltaTime * 5);
		}*/

	//Move to slides on Phone
		if (Input.acceleration.x != 0) {
			currentSpeed = Input.acceleration.x * (controlspeed) * 1.2f;

			if(currentSpeed >= maxSpeed) {
				currentSpeed = maxSpeed;
			}
			transform.Translate(Vector3.right * currentSpeed);

			if(currentRotatingTimer <= 0) {
				rotatingTo = car.transform.rotation.y + (Input.acceleration.x);
			} else {
				currentRotatingTimer -= Time.deltaTime;
			}

			car.transform.rotation = Quaternion.Slerp(Quaternion.identity, new Quaternion(
					car.transform.rotation.x, 
					rotatingTo, 
					car.transform.rotation.z, 
					car.transform.rotation.w), Time.deltaTime * 20);
		}
	}
}
