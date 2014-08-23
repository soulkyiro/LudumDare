using UnityEngine;
using System.Collections;

public class MainViewController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ApplicationController.Instance.GameController.guiInterface();
	}

}
