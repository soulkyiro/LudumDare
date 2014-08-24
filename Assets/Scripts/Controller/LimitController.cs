using UnityEngine;
using System.Collections;

public class LimitController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Astronaut")
        {
            ApplicationController.Instance.GameController.RestartLevel();
        }
    }
}
