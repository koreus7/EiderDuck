using UnityEngine;
using System.Collections;

public class SeekerAI : MonoBehaviour {

	public string targetName = "Player";
	private Transform _target;
	Rigidbody2D _rigidBody;
	public float speed = 2.0f;
	public float repelance = 1.0f;

	// Use this for initialization
	void Start () {
		_target = GameObject.Find (targetName).transform;
		_rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		//If we started before the player.
		if (_target == null) 
		{
			_target = GameObject.Find (targetName).transform;
		}

		Vector3 joiningLine = _target.transform.position - transform.position;
		Vector2 joiningLine2D = new Vector2 (joiningLine.x, joiningLine.y);

		Vector2 forceVector = joiningLine2D.normalized * speed;


		_rigidBody.AddForce (forceVector);
	}

	void NearEnemy(object enemy)
	{
		var enemyTransform = ((GameObject)enemy).transform;
		var distance = enemyTransform.position - transform.position;
		distance.Normalize ();
		_rigidBody.AddForce (distance*repelance); 
	}
	
}
