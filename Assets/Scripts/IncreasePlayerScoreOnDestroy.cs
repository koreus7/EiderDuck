using UnityEngine;
using System.Collections;

public class IncreasePlayerScoreOnDestroy : MonoBehaviour {

	public int amount = 10;

	void OnDestroy()
	{
		PlayerProperties.Inst.Score += amount;
	}
}
