using UnityEngine;
using System.Collections;

public class SignalController : MonoBehaviour {
    private bool target;
    private bool check = false;

	void OnTriggerEnter2D (Collider2D other)
    {
        if (!check)
        {
            if (other.gameObject.tag == "Astronaut")
            {
                Invoke("CheckPoint", 0.5f);
            }
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (!check) 
        { 
            if (other.gameObject.tag == "Astronaut")
            {
                target = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!check)
        {
            if (other.gameObject.tag == "Astronaut")
            {
                target = false;
            }
        }
    }

    private void CheckPoint()
    {
        if (target)
        {
            check = true;
            Debug.Log("Check Point");
            //ApplicationController.Instance.GameController.LevelController.CheckPointCounts();
        }
    }
}
