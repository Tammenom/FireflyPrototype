using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WoshPoint : MonoBehaviour {


    public AudioSource wosh;

   

    private int soundPlay;
    public AudioClip[] wSounds;

    // Use this for initialization
    void Start () {

        
   
    }
	

    void PlayWoshSound()
    {
        soundPlay = Random.Range(0, wSounds.Length-1);
        wosh.clip = wSounds[soundPlay];
        wosh.Play();

    }

    private void OnTriggerEnter()
    {
        
            PlayWoshSound();
        
    }

}
