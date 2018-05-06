using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSoundController : MonoBehaviour {

    public AudioClip[] damageSounds = new AudioClip[22];

    private AudioSource sound;

    // Use this for initialization
    void Start () {
        sound = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playNew()
    {
        sound.clip = damageSounds[Random.Range(0, damageSounds.Length)];
        sound.Play();
    }
}
