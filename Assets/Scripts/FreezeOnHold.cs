using UnityEngine;
using System.Collections;

public class FreezeOnHold : MonoBehaviour {

	HingeJoint2D _hingeJoint;

	// Use this for initialization
	void Start () {
		_hingeJoint = GetComponent<HingeJoint2D> (); 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Hold"))
		{
			_hingeJoint.useMotor = true;
		}
		else 
		{
			_hingeJoint.useMotor = false;
		}
	
	}
}
