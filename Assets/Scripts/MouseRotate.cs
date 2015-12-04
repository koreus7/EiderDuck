using UnityEngine;
using System.Collections;

public class MouseRotate : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		var ourScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
		var direction = Input.mousePosition - ourScreenPosition; 
		transform.rotation = Quaternion.Euler (new Vector3(0, 0, Mathf.Atan2 (direction.y,direction.x) * Mathf.Rad2Deg));
	}
}
