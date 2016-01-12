using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour {

	public static PlayerProperties Inst { get; private set; }

	public static GameObject Player { get { return Inst.gameObject; } }

	public static Vector3 Position  
	{
		get 
		{
			if(Inst == null)
			{
				return new Vector3(0,0,0);
			}
			else 
			{
				return Inst.gameObject.transform.position; 
			}
		} 
	}

	public Color explodeColor;

	public int DificultyLevel;

	public float defaultHealth = 3;
	public AudioClip hitSound;

	private AudioSource _audioSource;
	private float _health = 0;

	public int Score = 0;



	public PlayerProperties()
	{
		Inst = this;
	}

	// Use this for initialization
	void Start () 
	{
		_audioSource = GetComponent<AudioSource> ();
		_health = defaultHealth;//PlayerPrefs.GetFloat ("health", defaultHealth);
		DificultyLevel = PlayerPrefs.GetInt ("difficulty");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_health < 1) 
		{
			Die();
		}

		if (Input.GetKeyDown (KeyCode.H)) 
		{
			_health = defaultHealth;
		}
	}

	void Die()
	{
		GameObject instance  = (GameObject)Instantiate(Resources.Load("PlayerDieEffect"));
		instance.transform.position = this.transform.position;

		gameObject.SetActive (false);
	}
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.name.StartsWith("Enemy")) {
			_health -= 1;
			_audioSource.PlayOneShot(hitSound);
			coll.gameObject.BroadcastMessage("Hit");
		}
	}

	public void TakeDamage(float amount)
	{
		_health -= amount;
	}

	public void IncreaseHealth(float amount)
	{
		_health += amount;
	}

	void SaveProperties()
	{
		PlayerPrefs.SetFloat ("health"		,_health);
		PlayerPrefs.SetInt   ("difficulty"	,DificultyLevel);

		PlayerPrefs.Save ();
	}

	public void SceneSwitch()
	{
		SaveProperties ();
	}

	void OnApplicationQuit() 
	{
		SaveProperties ();
	}
}
