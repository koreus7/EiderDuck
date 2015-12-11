using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {

	public string sceneName;
	public float lag = 3.0f;

	private float _elapsed = 0.0f;
	private bool  _triggered = false;

	void Update()
	{
		if (_triggered) 
		{
			if(_elapsed < lag)
			{
				_elapsed += Time.deltaTime;
			}
			else 
			{
				_triggered = false;
				Application.LoadLevel(sceneName);
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.name == "Player") 
		{
			other.BroadcastMessage("SceneSwitch");
			_triggered = true;
		}
	}
}
