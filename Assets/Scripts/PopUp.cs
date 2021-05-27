using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for clean the progreess of the game.
/// </summary>
public class PopUp : MonoBehaviour
{
    public GameObject panel;
    private SoundController soundController;

    /// <summary>
    /// This function instantiates the sound and leaves the popup panel disabled.
    /// </summary>
    void Start()
    {
        panel.SetActive(false);
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
    }

    /// <summary>
    /// This function activates the confirmation panel.
    /// </summary>
    public void ActivePopUp()
    {
        panel.SetActive(true);
    }

    /// <summary>
    /// This function clean all progress of the game.
    /// </summary>
    public void CleanAll ( ) 
    {
        soundController.ButtonSound();
        float volumeSong = PlayerPrefs.GetFloat("volumeSong");
        float volumeEffects = PlayerPrefs.GetFloat("volumeEffects");
        
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetFloat("defaultValue", 0.2f);
        PlayerPrefs.SetFloat("volumeSong", volumeSong);
        PlayerPrefs.SetFloat("volumeEffects", volumeEffects);
        panel.SetActive(false);
    }
}