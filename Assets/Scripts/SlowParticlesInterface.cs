using UnityEngine;
using System.Collections;

/// <summary>
/// Slow particles interface.
/// 
/// So the particles game object can start and stop when the StartEfect and
/// StopEffect messages are broadcast
/// </summary>
public class SlowParticlesInterface : MonoBehaviour 
{

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
