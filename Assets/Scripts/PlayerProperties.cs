using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

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

	private int _score;

	public int Score 
	{ 
		get
		{
			return _score;
		} 
		set
		{
			_score = value;
			pointsText.text = value.ToString();

			//Make the score text pop up to show it has changed.
			pointsText.gameObject.transform.DOScale(3.5f,0.25f).SetEase(Ease.InBounce).OnComplete( ()=>{
				pointsText.gameObject.transform.DOScale(1.0f,0.1f).SetEase(Ease.InOutCubic);
			});

		} 
	}

	public DuckUI healthUI;

	public Text pointsText;

	private const float healthUIMultiplier = 100.0f;



	public PlayerProperties()
	{
		Inst = this;
	}

	// Use this for initialization
	void Start () 
	{
		_health = defaultHealth;
		_audioSource = GetComponent<AudioSource> ();
		DificultyLevel = PlayerPrefs.GetInt ("difficulty");
		Score = 0;
	}

	
	// Update is called once per frame
	void Update ()
	{
		healthUI.maxHealth = (int)Mathf.Floor (defaultHealth * healthUIMultiplier);

		healthUI.SetHealth ( (int)Mathf.Floor (_health * healthUIMultiplier) );

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
