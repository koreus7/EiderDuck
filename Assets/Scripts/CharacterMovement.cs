using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	Rigidbody2D _rigidBody;

	public Rigidbody2D walkingRigidBody;
	public Rigidbody2D swimmingRigidBody;

	public float normalDrag = 3.11f;
	public float swimmingDrag = 5.1f;

	public float normalMass = 0.42f;
	public float swimmingMass = 0.2f;

	Vector2 _inputAxes;

	public float speed;
	

	// Use this for initialization
	void Start () 
	{
		_rigidBody = GetComponent<Rigidbody2D> ();
		_inputAxes = new Vector2 ();
		StartWalking ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		_inputAxes.x = Input.GetAxis ("Horizontal");
		_inputAxes.y = Input.GetAxis ("Vertical"); 

		_rigidBody.AddForce (_inputAxes*speed);

		if (Input.GetKeyDown (KeyCode.P))
		{
			StartSwimming();
		}
	
	}

	public void StartSwimming()
	{
		_rigidBody.mass = swimmingMass;
		_rigidBody.drag = swimmingDrag;
	}

	public void StartWalking()
	{
		_rigidBody.mass = normalMass;
		_rigidBody.drag = normalDrag;
	}
}
