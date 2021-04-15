using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class QuitGame : MonoBehaviour
{
    public GameObject painel;
    private SoundController soundController;

    void Start()
    {
        painel.SetActive(false);
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
    }

    public void ActivePopUp()
    {
        painel.SetActive(true);
    }

      public void CloseGame ( ) 
    {
        soundController.ButtonSound();
        Application.Quit();
    }
}
