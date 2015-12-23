using UnityEngine;
using System.Collections;

public class KnockBackArgs
{
	public Vector2 center    { get; private set; }
	public float   magnitude { get; private set; }
	
	public KnockBackArgs(Vector2 center, float magnitude)
	{
		this.center = center;
		this.magnitude = magnitude;
	}
}
