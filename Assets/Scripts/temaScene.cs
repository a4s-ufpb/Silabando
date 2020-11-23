using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class temaScene : MonoBehaviour
{

    public Button btnJogar;
    
    void Start()
    {
        btnJogar.interactable = false;
    }

    public void jogar ()
    {
        int idScene = PlayerPrefs.GetInt("idTema");

        if(idScene != 0)
        {
            SceneManager.LoadScene(idScene.ToString());
        }

    }

}
