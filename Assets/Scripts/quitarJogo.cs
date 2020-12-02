using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class quitarJogo : MonoBehaviour
{
    public GameObject painel;
    private soundController soundController;

    void Start()
    {
        painel.SetActive(false);
        soundController = FindObjectOfType(typeof(soundController)) as soundController;
    }

    public void ativarPopUp()
    {
        painel.SetActive(true);
    }

      public void closeGame ( ) 
    {
        soundController.playbutton();
        Application.Quit();
    }
}
