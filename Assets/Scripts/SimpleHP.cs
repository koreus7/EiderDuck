using UnityEngine;
using System.Collections;

/// <summary>
/// SimpleHP.
/// 
/// Keeps track of an HP and can recieve damage.
/// </summary>
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
		FloatText (amount);
	}

	//Take damage based on our resitance.
	public void Hit()
	{

		health -= hitDamage;
		FloatText (hitDamage);
	}

	void FloatText(float amount)
	{
		if (amount != 0)
		{
			FloatingTextManager.MakeFloatingText (transform, FloatingTextManager.FormatDamage (-amount), Color.green);
		}
	}
}
