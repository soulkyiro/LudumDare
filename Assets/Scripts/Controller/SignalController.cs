using UnityEngine;
using System.Collections;

public class SignalController : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Astronaut"){
			Debug.Log ("Lo tienes");
		}
	}
}
