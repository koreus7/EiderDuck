using UnityEngine;
using System.Collections;

/// <summary>
/// Destroy self when particle system is finished.
/// </summary>
public class ParticleAutoDelete : MonoBehaviour {

	private ParticleSystem _particleSystem;

	public float lag = 2.0f;

	// Use this for initialization
	void Start () {
		_particleSystem = GetComponent<ParticleSystem> ();


		if (!_particleSystem.loop) 
		{
			Destroy(this.gameObject, _particleSystem.duration + lag);
		}
	}

}
