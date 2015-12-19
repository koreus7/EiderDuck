using UnityEngine;
using System.Collections;

public class ParticlesOnDie : MonoBehaviour 
{
	public GameObject particlesPrefab;

	void Die()
	{
		GameObject instance = MakeParticles ();
		instance.transform.position = this.transform.position;
		Camera.main.SendMessageUpwards ("ShakeWithIntensity", 2.0f);

		Destroy (gameObject);
	}

	GameObject MakeParticles()
	{
		if (particlesPrefab == null)
		{
			return (GameObject)Instantiate(Resources.Load("ExplodeParticles"));
		}

		return Instantiate(particlesPrefab);
	}
}
