using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for configure the options of the game.
/// </summary>
public class Options : MonoBehaviour
{
    private SoundController soundController;

    public GameObject panel1, panel2;
    public Slider volumeS, volumeE;

    /// <summary>
    /// This method instantiate the sound, load the player preferences and brings the first panel active.
    /// </summary>
    void Start()
    {
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        LoadPreferences();
        panel1.SetActive(true);
        panel2.SetActive(false);
    }
    /// <summary>
    /// This method can turn on or turn off a panel.
    /// </summary>
    /// <param name="onOff">Clicking the button, activates the disabled panel and deactivates the enabled panel.</param>
    public void Configurations(bool onOff)
    {   
        soundController.ButtonSound();
        panel1.SetActive(!onOff);
        panel2.SetActive(onOff);
    }

    /// <summary>
    /// This method clean all progress of the game (whithout previous warning) and 
    /// configures the volume of the song and effects according a previous configuration.
    /// </summary>
    public void CleanProgress()
    {
        soundController.ButtonSound();
        float volumeSong = PlayerPrefs.GetFloat("volumeSong");
        float volumeEffects = PlayerPrefs.GetFloat("volumeEffects");
        
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("defaultValue", 1);
        PlayerPrefs.SetFloat("volumeSong", volumeSong);
        PlayerPrefs.SetFloat("volumeEffects", volumeEffects);
    }    

    /// <summary>
    /// This method get the actual volume of the song and save in the configurations.
    /// </summary>
    public void VolumeSong()
    {
        soundController.audioSong.volume = volumeS.value;
        PlayerPrefs.SetFloat("volumeSong", volumeS.value);
    }
    
    /// <summary>
    /// This method get the actual volume of the effects and save in the configurations.
    /// </summary>
    public void VolumeEffects()
    {
        soundController.audioFX.volume = volumeE.value;
        PlayerPrefs.SetFloat("volumeEffects", volumeE.value);
    }

    /// <summary>
    /// This method is responsible for get the values ​​of the song volume and effects.
    /// </summary>
    void LoadPreferences()
    {
        float volumeSong = PlayerPrefs.GetFloat("volumeSong");
        float volumeEffects = PlayerPrefs.GetFloat("volumeEffects");

        volumeS.value = volumeSong;
        volumeE.value = volumeEffects;
    }
}