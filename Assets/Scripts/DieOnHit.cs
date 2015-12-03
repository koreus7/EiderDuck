using UnityEngine;
using System.Collections;

public class DieOnHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Hit()
	{
		GameObject instance  = (GameObject)Instantiate(Resources.Load("ExplodeParticles"));
		instance.transform.position = this.transform.position;
		Destroy (this.gameObject);
		Camera.main.SendMessageUpwards ("Shake");
	}
}
