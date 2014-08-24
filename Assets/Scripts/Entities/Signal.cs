using UnityEngine;
using System.Collections;

public class Signal: MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Astronaut"){
				SetActive();
				ApplicationController.Instance.GameController.LevelController.AddLetter(transform.parent.gameObject.name);
		}
	}

	private void SetActive ()
	{
		gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        gameObject.GetComponent<AudioSource>().audio.Play();
        Debug.Log(gameObject.GetComponent<AudioSource>().audio.isPlaying);
	}
}
