using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour {

	public float health = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 1) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("Collision Player");
		if (coll.gameObject.name == "Enemy") {
			health -= 1;
			Destroy(coll.gameObject);
		}
	}
}
