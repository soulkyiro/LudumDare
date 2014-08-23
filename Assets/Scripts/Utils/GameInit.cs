using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {

	void Start () {
        App();
	}

    private ApplicationController App() {
        return ApplicationController.Instance;
    }

}
