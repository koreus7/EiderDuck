using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SwordSlashController : MonoBehaviour 
{

	public GameObject sword;
	SpriteRenderer _sprite;

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
		var ourScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
		var direction = Input.mousePosition - ourScreenPosition; 
		
		float mouseAngle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;

		float current = transform.rotation.z;


		float startAngle = mouseAngle - 70f;
		float finishAngle = mouseAngle + 70f;

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

		transform.DORotate (new Vector3 (0, 0, finishAngle), 0.15f, RotateMode.Fast)
			.SetEase (Ease.OutQuad)
			.OnComplete (() => {
					DisableSword();
			});;
	}
}
