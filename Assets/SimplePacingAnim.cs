using UnityEngine;
using System.Collections;
using DG.Tweening;
/// <summary>
/// Simple pacing animation.
/// 
/// Makes the character walk left to right, pausing on the turn.
/// Nothing clever going on here just some tweening.
/// </summary>
public class SimplePacingAnim : MonoBehaviour 
{

	public Animator animator;

	bool walkRight = true;

	float distance = 40.0f;

	// Use this for initialization
	void Start () 
	{
		WalkRight ();
	}

	void WalkRight()
	{
		animator.SetTrigger ("walkRight");

		transform.DOLocalMoveX (distance, 2.0f).OnComplete (() =>
		{
			walkRight = false;
			Wait();
		}).SetEase(Ease.Linear);
	}

	void WalkLeft()
	{
		animator.SetTrigger ("walkLeft");

		transform.DOLocalMoveX (0, 2.0f).OnComplete (() =>
		{
			walkRight = true;
			Wait();
		}).SetEase(Ease.Linear);
			
	}

	void Wait()
	{
		animator.SetTrigger ("wait");
		Timer.New (gameObject, 1.5f, () =>
		{
			if (walkRight)
			{
				WalkRight();
			}
			else
			{
				WalkLeft();
			}

		});

	}

}
