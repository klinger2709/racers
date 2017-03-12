using UnityEngine;
using System.Collections;

public class ResetStreets : MonoBehaviour {

	void OnCollisionEnter(Collision col) 
	{
		if (col.gameObject.tag == "Street") 
		{
			col.transform.position = new Vector3(col.transform.position.x, col.transform.position.y, (col.transform.position.z + 100 * 3));
		}
	}

}
