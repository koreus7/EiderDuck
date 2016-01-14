using UnityEngine;
using System.Collections;

public class FoodPickup : MonoBehaviour {

	public string foodName = "Apple";

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "Player")
		{
			col.gameObject.GetComponent<Food>().ObtainFood(foodName,1);
		}

		Destroy (gameObject);
	}
}
