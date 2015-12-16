using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public float radius = 10.0f;
	public float damage = 1.0f;
	public float force = 10000f;

	void MakeExplosionForce()
	{
		Vector3 pos = transform.position;
		
		Collider2D[] colliders = Physics2D.OverlapCircleAll (pos, radius);
		
		foreach (Collider2D collider in colliders)
		{
			collider.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

			Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
			
			if(rb != null)
			{
				rb.AddExplosionForce(force, pos, radius);
			}
		}
	}

	
	void OnDrawGizmos()
	{
		var color = Color.yellow;
		color.a = 0.4f;
		Gizmos.color = color;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
}
