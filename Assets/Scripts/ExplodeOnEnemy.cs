using UnityEngine;
using System.Collections;

public class ExplodeOnEnemy : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.name.Contains ("Enemy"))
		{
			Explode();
		}
	}

	void Explode()
	{
		GameObject explosion = (GameObject)Instantiate (Resources.Load ("FireExplosion"));
		explosion.transform.position = this.transform.position;
		explosion.SendMessage ("MakeExplosionForce");

		Destroy (gameObject);
	}

}
