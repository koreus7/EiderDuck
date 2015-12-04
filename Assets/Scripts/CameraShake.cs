using UnityEngine;
using System.Collections;


/// <summary>
/// Shakes when Shake is called.
/// Need to put the camera as child to a gameobject with this
/// script atatched.
/// </summary>
public class CameraShake : MonoBehaviour {

	float _elapsedTime = 0.0f;
	float _shakeTime   = 0.5f;
	float _shakeIntensity = 0.0f;
	float _noiseScale = 20.0f;

	private bool _shaking = false;

	public void Shake()
	{
		ShakeWithIntensity (10.0f);
	}

	public void ShakeWithIntensity(float intensity)
	{
		_shaking = true;
		_elapsedTime = 0.0f;
		_shakeIntensity = intensity;
	}

	void FixedUpdate () 
	{

		if (_shaking) 
		{
			if (_elapsedTime < _shakeTime) 
			{
				_elapsedTime += Time.deltaTime;

				Vector3 pos = transform.position;

				pos.x = MakeNoise (0.0f);
				pos.y = MakeNoise (-1.0f);

				transform.position = pos;
			}
			else 
			{
				_shaking = false;

			}
		} 
		else 
		{
			//Return position to 0
			transform.position = Vector3.Lerp(transform.position, 
			                                  new Vector3(0,0,this.transform.position.z),
			                                  Time.deltaTime);
		}
	}

	float MakeNoise(float offset)
	{
		float x, y;
		x = y = (_elapsedTime + offset) * _noiseScale;

		float noise = Mathf.PerlinNoise (x,y)* _shakeIntensity;

		//Change the domain from 0 -> 1 to -1 -> 1
		float domainNoise = 2 * noise - 1;

		return domainNoise;
	}
}
