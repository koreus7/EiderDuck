using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	public float maxSpeed = 5.0f;

	public float acceleration = 2.0f;

	private Vector2 _velocity;

	private float minimumDistance = 20.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 deltaX3D = target.position - transform.position;

		if (deltaX3D.magnitude > minimumDistance) {

			Vector2 deltaX = new Vector2 (deltaX3D.x, deltaX3D.y);



			_velocity = deltaX.normalized * maxSpeed;

			Vector3 newPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime);//transform.position;
			newPosition.z = transform.position.z;

			//newPosition.x += _velocity.x * Time.deltaTime;
			//newPosition.y += _velocity.y * Time.deltaTime;
	    
			transform.position = newPosition;
		}
	}
}
