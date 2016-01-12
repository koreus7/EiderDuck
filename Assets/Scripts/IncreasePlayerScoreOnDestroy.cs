using UnityEngine;
using System.Collections;

public class IncreasePlayerScoreOnDestroy : MonoBehaviour {

	int amount = 10;

	void OnDestroy()
	{
		PlayerProperties.Inst.Score += amount;
	}
}
