using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	Rigidbody2D _rigidBody;

	Vector2 _inputAxes;

	public float speed;
	

	// Use this for initialization
	void Start () {

		_rigidBody = GetComponent<Rigidbody2D> ();
		_inputAxes = new Vector2 ();
	}
	
	// Update is called once per frame
	void Update () {

		_inputAxes.x = Input.GetAxis ("Horizontal");
		_inputAxes.y = Input.GetAxis ("Vertical"); 

		_rigidBody.AddForce (_inputAxes*speed);
	
	}
}
