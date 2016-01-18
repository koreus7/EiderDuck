using UnityEngine;
using System.Collections;

public class PowerupPickup : MonoBehaviour 
{

	public string powerUpName = "mv1";
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "Player")
		{
			col.gameObject.GetComponent<Powerups>().EnablePowerup(powerUpName);
		}
		
		Destroy (gameObject);
	}
}
