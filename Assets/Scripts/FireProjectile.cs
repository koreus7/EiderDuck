using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {

	public GameObject projectilePrefab;
	
	public bool mouseAim = true;

	public float speed = 5.0f;

	public Transform target;

	void Fire()
	{
		Vector3 target;
		if (mouseAim)
		{
			target = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		} 
		else
		{
			target = this.target.position;
		}
		 
		Vector3 direction3D =  this.transform.position - target; 
		Vector2 direction = new Vector2 (direction3D.x, direction3D.y);

		direction.Normalize();

		var angle = Quaternion.Euler (0, 0, Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg);

		GameObject projectile = (GameObject)Instantiate (projectilePrefab, transform.position, angle);

		var projectileRigidBody = projectile.GetComponent<Rigidbody2D> ();

		projectileRigidBody.AddForce (-(direction * speed), ForceMode2D.Impulse);

	}
}
