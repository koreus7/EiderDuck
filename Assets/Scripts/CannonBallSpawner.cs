using UnityEngine;
using System.Collections;

public class CannonBallSpawner : MonoBehaviour {

	public Rigidbody2D ball ;
	public float timer = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timer <= 0.0f)
		{
			Vector3 cannonSpawn = this.transform.position;
			Vector3 dire = (PlayerProperties.Position - cannonSpawn);
			Rigidbody2D CBall = Instantiate (ball, cannonSpawn, Quaternion.identity) as Rigidbody2D;
			CBall.AddForce (dire.normalized * 200);
			timer = 0.5f;
		} else
		{
			timer -= Time.deltaTime; 
		}
	}
}