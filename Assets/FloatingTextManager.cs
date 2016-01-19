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

	public static GameObject MakeFloatingText(Transform source, string text, Color color)
	{
		Debug.Log ("Effort Points!!!");
		GameObject floatingText = (GameObject)Instantiate (Inst.floatingTextPrefab, source.transform.position, Quaternion.identity);

		floatingText.transform.SetParent (Inst.gameObject.transform);

		var script = floatingText.GetComponent<FloatingText> ();

		script.color = color;
		script.textString = text;
		script.runTime = 1.0f;
		script.source = source;

		script.BeginFloating ();


		return floatingText;
	}

}
