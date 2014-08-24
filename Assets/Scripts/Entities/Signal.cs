using UnityEngine;
using System.Collections;

public class Signal: MonoBehaviour {

	private bool activated = false;
	private float fireworksLifetime = 5.0f;
	public GameObject fireworksPrefab;

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Astronaut"){
				SetActive();
		}
	}

	private void SetActive ()
	{
		if (!activated){
			ThrowFireworks();
			gameObject.GetComponent<SpriteRenderer>().color = Color.green;
			gameObject.GetComponent<AudioSource>().audio.Play();
			ApplicationController.Instance.GameController.LevelController.AddLetter(transform.parent.gameObject.name);
			activated = true;
		}
	}

	void ThrowFireworks ()
	{
		GameObject fireworks = GameObject.Instantiate (fireworksPrefab, transform.position, Quaternion.identity) as GameObject;
		Destroy (fireworks, fireworksLifetime);
	}
}
