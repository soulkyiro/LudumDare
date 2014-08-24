using UnityEngine;
using System.Collections;

public class AstronautParticleEmiterController : MonoBehaviour {

	public GameObject outerCore;
	public GameObject innerCore;
	public GameObject smoke;

	public void Enable (bool setter){
		outerCore.particleEmitter.emit = setter;
		innerCore.particleEmitter.emit = setter;
		smoke.particleEmitter.emit = setter;
	}
}
