using UnityEngine;
using System.Collections;

public class ManageSounds : MonoBehaviour {
	public AudioClip coin;
	public AudioClip crash;

	private AudioSource audioS;

	void Awake() {
		audioS = gameObject.GetComponent<AudioSource> ();
	}

	public void PlayCrashed() {
		audioS.Stop ();
		audioS.PlayOneShot (crash);
	}

	public void PlayCoinSound() {
		audioS.PlayOneShot (coin);
	}
}
