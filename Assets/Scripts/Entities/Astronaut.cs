using UnityEngine;
using System.Collections;

public class Astronaut : MonoBehaviour
{

		private float fuel = 100.0f;
		private float life;
		private float force = 1000.0f;
		private float softForce = 500.0f;
		private float fuelConsumption = 0.5f;
		private float speed = 0;
		private float speedFrontier = 100;
		private float health = 100;
		public GameObject trail;

		void Update ()
		{
			trail.GetComponent<AstronautParticleEmiterController>().Enable(Fly ());
		}

		void FixedUpdate() 
		{
			speed = gameObject.rigidbody2D.velocity.magnitude;
			Debug.Log ((int)speed);
		}

		private bool Fly ()
		{
				if (Input.GetKey ("a")) {
						FlyLeft ();
						return true;
				}
				if (Input.GetKey ("d")) {
						FlyRight ();
						return true;
				}
				if (Input.GetKey ("w")) {
						FlyUp ();
						return true;
				}
				return false;

		}

		void OnCollisionEnter2D (Collision2D other){
		if (TooMuchSpeed()) {
			Debug.LogWarning("OUCH!!");
			Hurts();
		}
		}

		private bool TooMuchSpeed ()
		{
			return speed > speedFrontier;
		}

		private void Hurts ()
		{
			health -= 20;
		}
		

		private void FlyLeft ()
		{
				gameObject.transform.rigidbody2D.AddForce (Vector2.up * softForce);
				gameObject.transform.rigidbody2D.AddForce (Vector2.right * -softForce);
				RestFuel ();

		}

		private void FlyRight ()
		{
				gameObject.transform.rigidbody2D.AddForce (Vector2.up * softForce);
				gameObject.transform.rigidbody2D.AddForce (Vector2.right * softForce);
				RestFuel ();

		}

		void FlyUp ()
		{
				gameObject.transform.rigidbody2D.AddForce (Vector2.up * force);
				RestFuel ();
		}

		void RestFuel ()
		{
				fuel -= fuelConsumption;
				//Debug.Log (fuel);
				if (fuel < 0) {
						Debug.Log ("No Fuel");
				}
		}
}
