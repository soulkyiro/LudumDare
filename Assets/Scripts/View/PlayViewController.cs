using UnityEngine;
using System.Collections;

public class PlayViewController : MonoBehaviour {

    void Start()
    {
        ApplicationController.Instance.GUIController.View = "PLAY";
        
    }
}
