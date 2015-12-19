using UnityEngine;
using System.Collections;

public class SimpleHealthBar : MonoBehaviour 
{

	public GameObject entityToWatch;

	IHealthManager _healthManager;
	SpriteRenderer _renderer;

	// Use this for initialization
	void Start () 
	{
		_renderer = GetComponentInChildren<SpriteRenderer> ();

		_healthManager = entityToWatch.GetComponent (typeof(IHealthManager)) as IHealthManager;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float percentage = _healthManager.Health / _healthManager.MaxHealth;

		_renderer.color = new Color (1.0f - percentage, percentage, 0.1f);
		transform.localScale = new Vector3 (percentage, 1, 1);
	}
}
