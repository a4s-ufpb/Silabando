using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This class is used for control any commands of UI buttons.
/// </summary>
public class BtnCommands : MonoBehaviour
{
    private SoundController soundController;
    
    /// <summary>
    /// This method is instantiating only the sound controller. 
    /// In any place if it called, it will reproduces a sound.
    /// </summary>
    void Start()
    {
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
    }

    /// <summary>
    /// This method loads a scene with its specific name.
    /// </summary>
    /// <param name="sceneName">Name of the scene then will load.</param>
    public void GoToScene (string sceneName) 
    {
        soundController.ButtonSound();
        SceneManager.LoadScene(sceneName);
    }
    
    /// <summary>
    /// This method identifies the current scene and if the player wants to, he can play it again.
    /// </summary>
    public void PlayAgain()
    {
        soundController.ButtonSound();
        int sceneID = PlayerPrefs.GetInt("themeID");

        if(sceneID != 0) SceneManager.LoadScene(sceneID.ToString());
    }
}
