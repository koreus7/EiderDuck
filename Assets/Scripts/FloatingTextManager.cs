using UnityEngine;
using System.Collections;

/// <summary>
/// FloatingTextManager.
/// 
/// Creates floating text objects.
/// 
/// Should be placed on the Canvas object.
/// </summary>
public class FloatingTextManager : MonoBehaviour 
{
	public GameObject floatingTextPrefab;
	public static FloatingTextManager Inst;

	public FloatingTextManager()
	{
		Inst = this;
	}

	public static string FormatDamage(float amount)
	{
		return ((int)Mathf.Floor (amount)).ToString ();
	}

	void Awake()
	{

		var canvas = GetComponent<Canvas> ();
		PauseManager.OnPaused += () => 
		{
			canvas.enabled = false;
		};

		PauseManager.OnResumed += () => 
		{
			canvas.enabled = true;
		};
	}

	public static GameObject MakeFloatingText(Transform source, string text, Color color, float runtime = 1.0f)
	{
		GameObject floatingText = (GameObject)Instantiate (Inst.floatingTextPrefab, source.transform.position, Quaternion.identity);

		floatingText.transform.SetParent (Inst.gameObject.transform);

		var script = floatingText.GetComponent<FloatingText> ();

		script.color = color;
		script.textString = text;
		script.runTime = runtime;
		script.source = source;

		script.BeginFloating ();


		return floatingText;
	}

}
