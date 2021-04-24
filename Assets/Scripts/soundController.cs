using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource audioSong, audioFX;
    public AudioClip correctSound, wrongSound, buttonSound, threeStars;
    public AudioClip [] songs;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }   
    void Start()
    {
        LoadPreferences();
        audioSong.clip = songs[0];
        audioSong.Play();

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
/// <summary>
/// Verify if have registries of initial values of coonfiguration and if don't have, save the initial values;
/// </summary>
    void LoadPreferences()
    {
    
        if(PlayerPrefs.GetInt("defaultValues") == 0)
        {
            PlayerPrefs.SetInt("defaultValues", 1);
            PlayerPrefs.SetFloat("volumeSong", 1);
            PlayerPrefs.SetFloat("volumeEffects", 1);
        }
        
        float volumeSong = PlayerPrefs.GetFloat("volumeSong");
        float volumeEffects = PlayerPrefs.GetFloat("volumeEffects");

        audioSong.volume = volumeSong;
        audioFX.volume = volumeEffects;
    }
}