using UnityEngine;
using System.Collections;

public class CannonSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Vector3 rando = new Vector3 (Random.Range (-100, 100), Random.Range (-100, 100), 0);
		GameObject cannon = Instantiate (Resources.Load ("Cannon"), rando, Quaternion.identity) as GameObject;





	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
