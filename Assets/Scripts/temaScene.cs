using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class temaScene : MonoBehaviour
{

    public Button btnJogar;

    [Header("Configuração da paginação")]
    public GameObject [] btnPaginação;
    public GameObject[] painelTemas;

    private bool ativarBtnPaginacao;

    
    void Start()
    {
        onOffButtons();

    }

    void onOffButtons()
    {
        btnJogar.interactable = false;

        if (painelTemas.Length > 1)
        {
           ativarBtnPaginacao = true;
        }
        else
        {
            ativarBtnPaginacao = false;
        }
         
        foreach(GameObject b in btnPaginação)
        {
            b.SetActive(true);
        }
    }

    public void jogar ()
    {
        int idScene = PlayerPrefs.GetInt("idTema");

        if(idScene != 0)
        {
            SceneManager.LoadScene(idScene.ToString());
        }

    }
    
    public void btnPagina (int i)
    {

    }

}
