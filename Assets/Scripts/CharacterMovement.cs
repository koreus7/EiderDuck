using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	Rigidbody2D _rigidBody;

	Vector2 _inputAxes;

	bool _swimming;
	bool _inWater;
	

	public float normalDrag = 10f;
	public float normalMass = 0.1f;

	public float swimmingDrag = 1.11f;
	public float swimmingMass = 0.42f;
	
	public float speed = 160.7f;

	
	void Start () 
	{
		_inputAxes = new Vector2 ();
		StartWalking ();
	}

	void Awake()
	{
		_rigidBody = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate()
	{
		_inputAxes.x = Input.GetAxis ("Horizontal");
		_inputAxes.y = Input.GetAxis ("Vertical"); 
		
		_rigidBody.AddForce (_inputAxes*speed);
	}



	public void StartSwimming()
	{
		_rigidBody.mass = swimmingMass;
		_rigidBody.drag = swimmingDrag;
		_swimming = true;
		gameObject.BroadcastMessage ("StartedSwimming");
	}

	public void StartWalking()
	{
		_rigidBody.mass = normalMass;
		_rigidBody.drag = normalDrag;
		_swimming = false;
		gameObject.BroadcastMessage ("StartedWalking");
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "water")
		{
			StartSwimming();
		} 
		else if (other.gameObject.tag == "ground")
		{
			StartWalking();
		}
	}
}
