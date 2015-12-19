using UnityEngine;
using System.Collections;

public class SimpleHP : MonoBehaviour, IHealthManager 
{
	//IHealthManager implimentations
	public float Health { get { return health; }}
	public float MaxHealth  { get { return maxHealth; } } 

	//public for inspector
	public float maxHealth = 20.0f;

	public float hitDamage = 1.0f;


	float health = 1.0f;

	void Start()
	{
		health = maxHealth;
	}


	void Update () 
	{
		if (health <= 0)
		{
			this.SendMessage("Die");
		}
	}

	//Take specific damage.
	public void TakeDamage(float amount)
	{
		health -= amount;
	}

	//Take damage based on our resitance.
	public void Hit()
	{
		health -= hitDamage;
	}
}
