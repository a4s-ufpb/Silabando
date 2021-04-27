using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for quit the game.
/// </summary>
public class QuitGame : MonoBehaviour
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
    /// This function ends the game.
    /// </summary>
    public void CloseGame ( ) 
    {
        soundController.ButtonSound();
        Application.Quit();
    }
}
