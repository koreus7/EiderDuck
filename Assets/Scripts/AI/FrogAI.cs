using UnityEngine;
using System.Collections;

public class FrogAI : MonoBehaviour 
{
	
	public string targetName = "Player";
	
	public float hopPeriod = 1.5f;
	
	public float hopTime = 1.0f;
	
	public float hopLatency = 0.1f;
	
	public float range = 20.0f;
	
	float elapsedSinceHop = 0.0f;

	public GameObject particlePrefab;


	
	private Explode _explodeScript;
	private Transform _target;
	private Vector3 hopTarget = new Vector2();
	private Vector3 positionBeforeHop = new Vector2();
	private bool _hopping;
	private BoxCollider2D _boxCollider;
	
	void Start () 
	{
		_target = GameObject.Find (targetName).transform;
		_boxCollider = gameObject.GetComponent<BoxCollider2D> ();

		_explodeScript = gameObject.GetComponent<Explode> ();

	}
	
	
	void Update () 
	{
		
		//If we started before the player.
		if (_target == null) 
		{
			_target = GameObject.Find (targetName).transform;
		}
		
		
		elapsedSinceHop += Time.deltaTime;
		
		//Look where the target is and store it early (so it is not perfectly accurate).
		if (elapsedSinceHop > hopPeriod - hopLatency)
		{
			StoreTargetPosition();
		}
		
		
		if (elapsedSinceHop > hopPeriod )
		{
			StartHop();
		}
		
		if (_hopping)
		{

			
			if(elapsedSinceHop > hopTime)
			{
				_explodeScript.MakeExplosionForce(1.0f);
				_hopping = false;
				elapsedSinceHop = 0.0f;
			}
			else 
			{
				CalculateHopPosition();
			}
		}

		_boxCollider.isTrigger = _hopping;
	}
	
	void CalculateHopPosition()
	{
		Vector3 hopLine = hopTarget - positionBeforeHop;
		
		float hopLineMagnitude = hopLine.magnitude;
		Vector3 hoplineDirection = hopLine.normalized;
		
		float percentageHopDone = elapsedSinceHop / hopTime;


		

		
		Vector3 newPosition = positionBeforeHop + hoplineDirection * hopLineMagnitude * percentageHopDone;


		//scale is is the parabolic curve -x(x -1) + 1
		//       . .
		//     .     .
		//    .       .

		float scale = -percentageHopDone * (percentageHopDone - 1) + 1;
		transform.localScale = new Vector3 (scale, scale,transform.localScale.z);
		
		//Only move in 2D.
		newPosition.z = transform.position.z;
		
		transform.position = newPosition;
		
	}
	
	void StoreTargetPosition()
	{
		Vector3 joiningLine = transform.position - _target.transform.position;
		
		if (joiningLine.magnitude < range)
		{
			hopTarget = _target.transform.position;
		}
		else if (joiningLine.magnitude < range*3.0f)
		{
			//Move in the direction of the target at maximum range.
			hopTarget = (_target.transform.position - transform.position).normalized * range;
		}
		//If it will take more than three hops then just hop around instead.
		else
		{
		
			Vector3 direction = new Vector3 (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f));
			//hop around aimlessly
			hopTarget = direction * Random.Range (0.3f, range);
		}


	}

	void StartHop()
	{
		elapsedSinceHop = 0.0f;
		positionBeforeHop = transform.position;
		_hopping = true;
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawLine (transform.position, hopTarget);
		Gizmos.DrawWireSphere (transform.position, range);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.name == "Player")
		{
			Instantiate (particlePrefab, transform.position, transform.rotation);
			collider.gameObject.SendMessage("Slow");
		}


	}


}
