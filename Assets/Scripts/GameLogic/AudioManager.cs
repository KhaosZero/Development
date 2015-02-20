using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public GameObject m_Not_Enough_Wood1;
	public AudioSource au_Not_Enough_Wood1;
	// Use this for initialization
	void Start () {
		au_Not_Enough_Wood1 = (AudioSource)gameObject.AddComponent ("AudioSource");
		AudioClip Not_Enough_Wood1;
		Not_Enough_Wood1 = (AudioClip)Resources.Load ("Audio/Voice/Wood/not_enough_wood1");
		au_Not_Enough_Wood1.clip = Not_Enough_Wood1;
		au_Not_Enough_Wood1.loop = false;
		//audio.volume = 1.0f;
		audio.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NotEnoughWood () {

		au_Not_Enough_Wood1.Play ();
	}
}
