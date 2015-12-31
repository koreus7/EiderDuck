using UnityEngine;
using System.Collections;


/// <summary>
/// Seeker AI
/// 
/// Moves towoards the target.
/// </summary>
public class SeekerAI : MonoBehaviour 
{

	public string targetName = "Player";
	private Transform _target;
	Rigidbody2D _rigidBody;
	public float speed = 2.0f;

	//How much we repel other enemies.
	public float repelance = 1.0f;

	//How close we get before we stop adding force.
	public float standOffDistance = 0.0f;

	// Use this for initialization
	void Start () 
	{
		_target = GameObject.Find (targetName).transform;
		_rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		//If players Start was called before our Start.
		if (_target == null) 
		{
			_target = GameObject.Find (targetName).transform;
		}

		//Line from us to the target
		Vector3 joiningLine = _target.transform.position - transform.position;
		Vector2 joiningLine2D = new Vector2 (joiningLine.x, joiningLine.y);

		//Force in the direction of the joining line.
		Vector2 forceVector = joiningLine2D.normalized * speed * (PlayerProperties.Inst.DificultyLevel + 1);


		if (joiningLine.magnitude > standOffDistance)
		{
			_rigidBody.AddForce (forceVector);
		}
	}

	public void NearEnemy(object enemy)
	{
		var enemyTransform = ((GameObject)enemy).transform;
		Vector3 distance = enemyTransform.position - transform.position;
		distance.Normalize ();

		//Repel self from enemy.
		_rigidBody.AddForce (-distance*repelance); 
	}
	
}
