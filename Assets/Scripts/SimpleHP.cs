using UnityEngine;
using System.Collections;

public class SimpleHP : MonoBehaviour {


	public float health = 20.0f;

	// Update is called once per frame
	void Update () 
	{
		if (health <= 0)
		{
			this.SendMessage("Die");
		}
	}

	public void TakeDamage(float amount)
	{
		Debug.Log ("Take " + amount);
		health -= amount;
	}

	public void Hit()
	{
		Debug.Log ("Hit");
		health = 0;
	}
}
