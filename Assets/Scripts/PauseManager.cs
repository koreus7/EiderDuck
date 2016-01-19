using UnityEngine;
using System.Collections;

/// <summary>
/// Pause manager.
/// 
/// Allows lots of custom behaviors on pause by centralising
/// pausing and providing pause events to subscribe to.
/// </summary>
public class PauseManager : MonoBehaviour 
{
	public delegate void PauseAction();
	public static event PauseAction OnPaused;
	public static event PauseAction OnResumed;
	public static bool Paused { get; private set; }
	
	public static void Pause()
	{
		if (OnPaused != null)
		{
			OnPaused();
		}

		Time.timeScale = 0.00001f;

		Paused = true;
	}

	public static void Resume()
	{
		if (OnResumed != null)
		{
			OnResumed();
		}

		Time.timeScale = 1.0f;

		Paused = false;
	}


}
