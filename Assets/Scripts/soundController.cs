using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for controlling the sounds of the game.
/// </summary>
public class SoundController : MonoBehaviour
{
    public AudioSource audioSong, audioFX;
    public AudioClip correctSound, wrongSound, buttonSound, threeStars;
    public AudioClip [] songs;

    /// <summary>
    /// This function is called on the "Splash" screen. 
    /// It is responsible for not destroying the audio between scenes.
    /// </summary>
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }   

    /// <summary>
    /// Load the player's settings and start the array of sounds.
    /// </summary>
    void Start()
    {
        LoadPreferences();
        audioSong.clip = songs[0];
        audioSong.Play();
    }

    /// <summary>
    /// Plays the sound of the correct answer.
    /// </summary>
    public void PlayAudioRightQuestion()
    {
        audioFX.PlayOneShot(correctSound);
    }

    /// <summary>
    /// Plays the sound of the wrong answer.
    /// </summary>
    public void PlayAudioWrongQuestion()
    {
        audioFX.PlayOneShot(wrongSound);
    }

    /// <summary>
    /// Plays the button click sound.
    /// </summary>
    public void ButtonSound()
    {
        audioFX.PlayOneShot(buttonSound);
    }

    /// <summary>
    /// Plays the sound of the score (stars).
    /// </summary>
    public void Stars()
    {
        audioFX.PlayOneShot(threeStars);
    }

    /// <summary>
    /// Verify if have registries of initial values of coonfiguration and if don't have, save the initial values;
    /// </summary>
    void LoadPreferences()
    {
    
        if(PlayerPrefs.GetFloat("defaultValue") == 0)
        {
            PlayerPrefs.SetFloat("defaultValue", 0.3f);
            PlayerPrefs.SetFloat("volumeSong", 0.3f);
            PlayerPrefs.SetFloat("volumeEffects", 0.5f);
        }
        
        float volumeSong = PlayerPrefs.GetFloat("volumeSong");
        float volumeEffects = PlayerPrefs.GetFloat("volumeEffects");

        audioSong.volume = volumeSong;
        audioFX.volume = volumeEffects;
    }
}