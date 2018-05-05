using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxController : MonoBehaviour {

    public AudioClip[] tracks = new AudioClip[4];

    AudioSource musicPlayer;
    bool changeTrackNow = false;
    float timePlayed = 0.0f;
    float playTime = 0.4f;

    // Use this for initialization
    void Start () {
        musicPlayer = transform.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        timePlayed += Time.deltaTime;
        tryChangeTrack();
    }

    // Call to change track
    public void changeTrack()
    {
        changeTrackNow = true;
        tryChangeTrack();
    }

    void tryChangeTrack()
    {
        if (changeTrackNow == true && timePlayed >= playTime)
        {
            setRandomTrack();
        }
    }

    private void setRandomTrack()
    {
        changeTrackNow = false;
        int songIndex = Random.Range(0, tracks.Length);
        musicPlayer.clip = tracks[songIndex];
        timePlayed = 0.0f;
        playTime = tracks[songIndex].length;
        musicPlayer.Play();
    }
}
