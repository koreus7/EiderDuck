using UnityEngine;
using System.Collections;

public class SlowParticlesInterface : MonoBehaviour {

	ParticleSystem _particleSystem;

	void Start()
	{
		_particleSystem = gameObject.GetComponent<ParticleSystem> ();
		_particleSystem.enableEmission = false;
	}


	void StartEffect () 
	{
		_particleSystem.enableEmission = true;
	
	}

	void StopEffect () 
	{
		_particleSystem.enableEmission = false;
	}
}
