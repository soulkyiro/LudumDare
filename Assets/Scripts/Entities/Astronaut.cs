using UnityEngine;
using System.Collections;

public class Astronaut : MonoBehaviour {

	private float fuel;

	void Update() {
		Fly();
	}

	void Fly ()
	{
		if (Input.GetKeyDown("a")){

			FlyLeft();
		}
		if (Input.GetKeyDown("d")){

			FlyRight();
		}
	}
	
	void FlyLeft ()
	{
		gameObject.transform.rigidbody2D.AddForce(Vector2.up * 10000.0f);
		gameObject.transform.rigidbody2D.AddForce(Vector2.right * -1000.0f);
		Debug.Log ("RIGHT");
	}

	void FlyRight ()
	{
		gameObject.transform.rigidbody2D.AddForce(Vector2.up * 10000.0f);
		gameObject.transform.rigidbody2D.AddForce(Vector2.right * 1000.0f);
		Debug.Log ("LEFT");
	}
}
