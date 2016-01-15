using UnityEngine;
using System.Collections;

/// <summary>
/// Character movement.
/// 
/// Controls the characters movement from user input.
/// </summary>
public class CharacterMovement : MonoBehaviour 
{
	
	Rigidbody2D _rigidBody;
	
	Vector2 _inputAxes;
	
	bool _swimming;
	bool _inWater;
	
	
	public float normalDrag = 10f;
	public float normalMass = 0.1f;
	
	public float swimmingDrag = 1.11f;
	public float swimmingMass = 0.42f;
	
	public float speed = 160.7f;
	
	//How long we slow down for when slowed.
	public float slowTime = 1.5f;
	
	//How much we slow down when slowed.
	public float slowPercentage  = 0.4f;
	
	public GameObject slowEffect;
	
	float slowTimeElapsed = 0.0f;
	bool currentlySlowed;


	// tracks if the player can or can't move
	// (based on the activation of the dialogue
	// system)
	public bool canMove;


	void Start () 
	{
		_inputAxes = new Vector2 ();
		StartWalking ();
	}
	
	void Awake()
	{
		_rigidBody = GetComponent<Rigidbody2D> ();
	}


	/// <summary>
	/// Slow down the player due to mud, slime or whatever the case may be.
	/// </summary>
	void Slow()
	{
		currentlySlowed = true;
		slowEffect.SendMessage("StartEffect");
		slowTimeElapsed = 0.0f;
	}
	
	void FixedUpdate()
	{

		if (!canMove)
		{
			// prevents the rest of the code from
			// executing if the player shouldn't move
			// at the moment
			return;
		}

		_inputAxes.x = Input.GetAxis ("Horizontal");
		_inputAxes.y = Input.GetAxis ("Vertical"); 
		
		
		Vector2 force = _inputAxes * speed;

		UpdateSlowState ();

		if (currentlySlowed)
		{
			force *= slowPercentage;
		}

		_rigidBody.AddForce (force);
	}

	//Keep track of the slow timer and state.
	void UpdateSlowState()
	{
		//When the slow effect is finished.
		if (slowTimeElapsed > slowTime)
		{
			currentlySlowed = false;
			slowEffect.SendMessage("StopEffect");
		} 
		
		slowTimeElapsed += Time.deltaTime;
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
