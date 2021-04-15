using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource audioMusic, audioFX;
    public AudioClip correctSound, wrongSound, buttonSound, threeStars;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }   
    void Start()
    {
        audioMusic.Play();
    }
    public void PlayAudioRightQuestion()
    {
        audioFX.PlayOneShot(correctSound);

    }
    public void PlayAudioWrongQuestion()
    {
        
        audioFX.PlayOneShot(wrongSound);
    }

    public void ButtonSound()
    {
        audioFX.PlayOneShot(buttonSound);
    }
    public void Stars()
    {
        audioFX.PlayOneShot(threeStars);
    }

}