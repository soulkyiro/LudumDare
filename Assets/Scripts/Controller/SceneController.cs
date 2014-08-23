using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	void Awake () {
        if (GameObject.Find("(singleton) ApplicationController") == null)
        {
            Application.LoadLevel("Init");
        }
	
	}
}
