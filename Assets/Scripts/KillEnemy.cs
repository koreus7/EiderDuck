using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour 
{

	public float minimumVelocity = 200.0f;

	private Vector3 _lastPosition;
	private Vector3 _velocity;

	private Rigidbody2D _rigidBody;
	private SpriteRenderer _renderer;
	public float knockBackAmount = 1.0f;



	// Use this for initialization
	void Start () 
	{
		_rigidBody = GetComponent<Rigidbody2D> ();
		_lastPosition = transform.position;
		_renderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		_velocity = (transform.position - _lastPosition) / Time.deltaTime;

		var color = _renderer.color;

		var percentageVelocity = _velocity.magnitude/minimumVelocity;
		percentageVelocity *= percentageVelocity;

		if (percentageVelocity < 0.5f) 
		{
			percentageVelocity = 0.1f;
		}

		color.a = Mathf.Lerp (color.a, Mathf.Clamp (percentageVelocity, 0f, 1f), Time.deltaTime*7.0f);

		_renderer.color = color;

		_lastPosition = transform.position;
	}



	void OnTriggerEnter2D(Collider2D other) 
	{
		if (_velocity.magnitude > minimumVelocity) 
		{
			other.SendMessage ("Hit", SendMessageOptions.DontRequireReceiver);
			other.SendMessage ("KnockBack", new KnockBackArgs(transform.position,knockBackAmount), SendMessageOptions.DontRequireReceiver);
		}

	}
}
