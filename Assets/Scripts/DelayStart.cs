using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using DG.Tweening;

/// <summary>
/// Delay start.
/// 
/// Delays the start of the scene with an animation.
/// 
/// All apologies for this filthy hack.
/// </summary>
public class DelayStart : MonoBehaviour 
{
	public CharacterMovement characterMovement;
	public Camera camera;
	VignetteAndChromaticAberration vingette;

	void Start () 
	{
		characterMovement.enabled = false;

		vingette = camera.GetComponent<VignetteAndChromaticAberration> ();
		vingette.intensity = 1.0f;

		DOTween.To (() =>
		{
			return vingette.intensity;
		}, (x) =>
		{
			vingette.intensity = x;
		}, 0.036f, 2.0f).OnComplete (() =>
		{
			characterMovement.enabled = true;
		}).SetEase(Ease.InOutCubic);

	}
	

	void Update () 
	{
		
	}
}
