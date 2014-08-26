using UnityEngine;
using System.Collections;

public class Satellite : MonoBehaviour {
    public Transform point;
	void Update () {
        transform.Rotate(0,0,0.8f);
	}
}
