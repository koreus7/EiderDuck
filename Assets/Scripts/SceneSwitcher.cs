using UnityEngine;

using System.Collections;

public class SceneSwitcher : MonoBehaviour 
{
	public string sceneName;

	public float lag = 3.0f;

	private float _elapsed = 0.0f;

	private bool  _triggered = false;

	bool canWarp = true;

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
				PlayerPrefs.SetString("WarpName", gameObject.name);
				Application.LoadLevel(sceneName);
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.name == "Player") 
		{
			if(canWarp)
			{
				other.BroadcastMessage("SceneSwitch");
				_triggered = true;
			}
		}
	}

	public void DisableForTime(float time)
	{
		canWarp = false;
		Timer.New (gameObject, time, () => {
			this.canWarp = true;
		});

	}
}
