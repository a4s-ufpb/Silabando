using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject panel1, panel2;
    private SoundController soundController;

    public Slider volumeS, volumeE;

    void Start()
    {
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        LoadPreferences();
        panel1.SetActive(true);
        panel2.SetActive(false);
    }
    
    public void Configurations(bool onOff)
    {   
        soundController.ButtonSound();
        panel1.SetActive(!onOff);
        panel2.SetActive(onOff);
    }

    /// <summary>
    /// This method clean all progress of the game (whithout previous warning);
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

    public void VolumeSong()
    {
        soundController.audioSong.volume = volumeS.value;
        PlayerPrefs.SetFloat("volumeSong", volumeS.value);
    }

    public void VolumeEffects()
    {
        soundController.audioFX.volume = volumeE.value;
        PlayerPrefs.SetFloat("volumeEffects", volumeE.value);
    }

    void LoadPreferences()
    {
        float volumeSong = PlayerPrefs.GetFloat("volumeSong");
        float volumeEffects = PlayerPrefs.GetFloat("volumeEffects");

        volumeS.value = volumeSong;
        volumeE.value = volumeEffects;
    }

}