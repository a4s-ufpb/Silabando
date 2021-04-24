using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class QuitGame : MonoBehaviour
{
    public GameObject panel;
    private SoundController soundController;

    void Start()
    {
        panel.SetActive(false);
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
    }

    public void ActivePopUp()
    {
        panel.SetActive(true);
    }

      public void CloseGame ( ) 
    {
        soundController.ButtonSound();
        Application.Quit();
    }
}
