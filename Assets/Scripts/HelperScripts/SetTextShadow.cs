using UnityEngine;
using System.Collections;

public class SetTextShadow : MonoBehaviour {

	public GUIText mainText;

	void Update () {
		gameObject.GetComponent<GUIText> ().text = mainText.text;
	}
}
