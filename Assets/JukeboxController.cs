using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxController : MonoBehaviour {

    public AudioClip[] tracks = new AudioClip[4];

    AudioSource musicPlayer;
    bool changeTrackNow = true;
    float timePlayed;
    float playTime;

    // Use this for initialization
    void Start () {
        musicPlayer = transform.GetComponent<AudioSource>();
        setRandomTrack();
    }
	
	// Update is called once per frame
	void Update () {
        playTime += Time.deltaTime;
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
        int songIndex = Random.Range(0, tracks.Length);
        musicPlayer.clip = tracks[songIndex];
        timePlayed = 0.0f;
        playTime = tracks[songIndex].length;
        musicPlayer.Play();
    }
}
