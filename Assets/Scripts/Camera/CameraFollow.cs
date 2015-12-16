using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;


	private float minimumDistanceX = 20.0f;
	private float minimumDistanceY = 5.0f;

	private float trackSpeedX = 1.0f;
	private float trackSpeedY = 2.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		Vector3 newPosition = transform.position;

		Vector3 targetDisplacement = target.position - transform.position;



		if (Mathf.Abs(targetDisplacement.x) > minimumDistanceX)
		{
			newPosition.x = Mathf.Lerp (transform.position.x, target.position.x, Time.deltaTime*trackSpeedX);
		}

		if (Mathf.Abs(targetDisplacement.y) > minimumDistanceY)
		{
			newPosition.y = Mathf.Lerp (transform.position.y, target.position.y, Time.deltaTime*trackSpeedY);
		}

	    
		transform.position = newPosition;
		
	}

	public void SetTarget(Transform target)
	{
		this.target = target;
	}
}
