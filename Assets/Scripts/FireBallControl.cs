using UnityEngine;
using System.Collections;

public class FireBallControl : MonoBehaviour {

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			gameObject.SendMessage("Fire");
			Camera.main.SendMessageUpwards ("ShakeWithIntensity", 1.2f);
		}
	}
}
