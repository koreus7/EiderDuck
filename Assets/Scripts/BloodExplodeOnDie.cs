using UnityEngine;
using System.Collections;

public class BloodExplodeOnDie : MonoBehaviour 
{
	void Die()
	{
		GameObject instance  = (GameObject)Instantiate(Resources.Load("ExplodeParticles"));
		instance.transform.position = this.transform.position;
		Camera.main.SendMessageUpwards ("ShakeWithIntensity", 2.0f);

		Destroy (gameObject);
	}
}
