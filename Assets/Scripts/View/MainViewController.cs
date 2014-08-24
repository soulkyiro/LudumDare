using UnityEngine;
using System.Collections;

public class MainViewController : MonoBehaviour {

	void Start () 
    {
        ApplicationController.Instance.GUIController.View = "MAIN";
	}

}
