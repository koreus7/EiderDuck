using UnityEngine;
using System.Collections;

public class FireBallControl : MonoBehaviour {

	float heldTime = 0.0f;

	public float fullChargeTime = 1.5f;

	public float fullChargeStrength = 3.0f;

	static string buttonName = "Fire1";

	public GameObject normalFireBall;
	public GameObject fullyChargedFireBall;

	FireProjectile _projectileLauncher;

	bool held = false;

	void Start() 
	{
		_projectileLauncher = gameObject.GetComponent<FireProjectile> ();
	}

	// Update is called once per frame
	void Update ()
	{

		if(Input.GetButtonDown(buttonName))
		{
			held = true;
		}
		if (Input.GetButtonUp (buttonName))
		{
			Release(heldTime);
			held = false;
			heldTime = 0.0f;
		}

		if (held)
		{
			heldTime += Time.deltaTime;
		}

	}

	void Release(float length)
	{
		float percentCharge = length / fullChargeTime;

		if (percentCharge >= 1.0f)
		{
			Debug.Log("Fully Charged");
			_projectileLauncher.projectilePrefab = fullyChargedFireBall;
		} 
		else
		{
			_projectileLauncher.projectilePrefab = normalFireBall;
		}

		float strength = Mathf.Clamp (percentCharge * fullChargeStrength, 1, fullChargeStrength);

		//Spamming the button
		if (length < 0.15f)
		{
			strength = 0.5f;
		}


		_projectileLauncher.Fire (strength);
		Camera.main.SendMessageUpwards ("ShakeWithIntensity", 1.0f);
	}
}
