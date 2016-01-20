using UnityEngine;
using System.Collections;
using DG.Tweening;


/// <summary>
/// SwordSlashController
/// 
/// Makes the sword rotate quickly around the area the player clicks.
/// </summary>
public class SwordSlashController : MonoBehaviour 
{

	public GameObject sword;
	SpriteRenderer _sprite;

	public AudioClip[] swipeSounds;
	public AudioSource audioSource;

	bool directionFlip;

	void Start()
	{
		_sprite = sword.GetComponent<SpriteRenderer> ();
		DisableSword ();
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Fire1"))
		{
			Swing();
		}
	}


	private void EnableSword()
	{
		sword.SetActive (true);
		_sprite.DOFade (1, 0.05f);
	}

	private void DisableSword()
	{
		sword.SetActive(false);
		_sprite.DOFade (0, 0.05f);
	}

	void Swing()
	{

		audioSource.clip = swipeSounds [Random.Range (0, swipeSounds.Length)];
		audioSource.Play ();

		var ourScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
		var direction = Input.mousePosition - ourScreenPosition; 
		
		float mouseAngle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;

		float current = transform.rotation.z;


		float startAngle  = mouseAngle - 70f;
		float finishAngle = mouseAngle + 70f;


		//Switch swing direction each swing.
		if (directionFlip)
		{
			float temp = startAngle;
			startAngle = finishAngle;
			finishAngle = temp;
			directionFlip = false;
		}
		else
		{
			directionFlip = true;
		}


		transform.rotation = Quaternion.Euler( new Vector3(0,0,startAngle));

		EnableSword ();

		transform.DORotate (new Vector3 (0, 0, finishAngle), 0.2f, RotateMode.Fast)
			.SetEase (Ease.Linear)
			.OnComplete (() => {
					DisableSword();
			});;
	}
}
