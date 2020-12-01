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

    private int idPagina;

    private soundController soundController;
    
    void Start()
    {
        soundController = FindObjectOfType(typeof(soundController)) as soundController;
        onOffBotoesPaineis();

    }

    void onOffBotoesPaineis()
    {
  
        btnJogar.interactable = false;

        foreach (GameObject p in painelTemas)
        {
            p.SetActive(false);

        }
        
        painelTemas[0].SetActive(true);

        
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
            b.SetActive(ativarBtnPaginacao);
        }
        

    }

    public void jogar ()
    {
        soundController.playbutton();
     
        int idScene = PlayerPrefs.GetInt("idTema");

        if(idScene != 0)
        {
            SceneManager.LoadScene(idScene.ToString());
        }

    }
    
    public void btnPagina (int i)
    {
        soundController.playbutton();
        idPagina += i;
        if (idPagina < 0)
        {
            idPagina = painelTemas.Length - 1;
        }
        else if (idPagina >= painelTemas.Length)
        {
            idPagina = 0;
        }

        btnJogar.interactable = false;
    

        foreach (GameObject p in painelTemas)
        {
            p.SetActive(false);

        }
        painelTemas[idPagina].SetActive(true);
    }

}
