using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This class is used for control any commands of UI buttons;
/// </summary>
public class BtnCommands : MonoBehaviour
{   
    /// <summary>
    /// In this public object, we can "power on/off" panels in UI;
    /// </summary>
    public GameObject panel1, panel2;

    /// <summary>
    /// We use this for configure sounds when press any button then was configured previously;
    /// </summary>
    private SoundController soundController;

    /// <summary>
    /// This method is instantiating only the sound controller. In any place if it called, it will reproduces a sound;
    /// </summary>
    void Start()
    {
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
    }

    /// <summary>
    /// This method loads a scene with its specific name;
    /// </summary>
    /// <param name="sceneName">Name of the scene then will load;</param>
    public void GoToScene (string sceneName) 
    {
        soundController.ButtonSound();
        SceneManager.LoadScene(sceneName);
    }
    
    /// <summary>
    /// This method identifies the current scene and if the player wants to, he can play it again;
    /// </summary>
    public void PlayAgain()
    {
        soundController.ButtonSound();
        int sceneID = PlayerPrefs.GetInt("themeID");

        if(sceneID != 0) SceneManager.LoadScene(sceneID.ToString());
    }

    /// <summary>
    /// This method can turn on or turn off a panel;
    /// </summary>
    /// <param name="onOff">Clicking the button, activates the disabled panel and deactivates the enabled panel</param>
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
        PlayerPrefs.DeleteAll();
    }
}
