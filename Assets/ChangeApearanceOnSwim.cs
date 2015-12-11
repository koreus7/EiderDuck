using UnityEngine;
using System.Collections;

public class ChangeApearanceOnSwim : MonoBehaviour {

	SpriteRenderer _spriteRenderer;

	void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void StartedSwimming()
	{
		_spriteRenderer.color = Color.green;
	}

	public void StartedWalking()
	{
		_spriteRenderer.color = Color.white;
	}
}
