using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour {
    AudioSource audio;

    public AudioClip[] hitSounds;
    public AudioClip win;
    public AudioClip spawn;

    void Start () {
        audio = GetComponent<AudioSource>();
	}

    public void PlayHit()
    {
        audio.clip = hitSounds[Random.Range(0, hitSounds.Length)];
        audio.pitch = Random.Range(1, 2.1f);
        audio.Play();
    }


    public void PlayWin()
    {
        audio.clip = win;
        audio.Play();
    }

    public void PlaySpawn()
    {

        audio.clip = spawn;
        audio.Play();
    }
}
