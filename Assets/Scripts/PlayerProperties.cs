using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour {

	public static PlayerProperties Inst { get; private set; }

	public float defaultHealth = 3;
	public AudioClip hitSound;

	private AudioSource _audioSource;
	private float _health = 0;

	public PlayerProperties()
	{
		Inst = this;
	}

	// Use this for initialization
	void Start () 
	{
		_audioSource = GetComponent<AudioSource> ();
		_health  = PlayerPrefs.GetFloat ("health", defaultHealth);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_health < 1) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Input.GetKeyDown (KeyCode.H)) 
		{
			_health = defaultHealth;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.name.StartsWith("Enemy")) {
			_health -= 1;
			_audioSource.PlayOneShot(hitSound);
			coll.gameObject.BroadcastMessage("Hit");
		}
	}

	void SaveProperties()
	{
		PlayerPrefs.SetFloat ("health", _health);
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
