using System;
using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class infoTema : MonoBehaviour
{


    private temaScene temaScene;
    [Header ("Identificação do tema")]
    public int idTema;
    public bool requerNotaMinima;
    public int notaMinimaNecessaria;
   
   
    [Header ("Configuração do botão")] 
    public Text idTemaTxt;
    public GameObject[] estrela;

    [Header ("Configuração das estrelas")] 
    public int min1Estrela, min2Estrelas;
   
    private int notaFinal;

    private Button btnTema;

    private soundController soundController;
   
    void Start()
    {
        soundController = FindObjectOfType(typeof(soundController)) as soundController;
        
        notaFinal = PlayerPrefs.GetInt("notaFinal_" + idTema.ToString());

        temaScene = FindObjectOfType (typeof(temaScene)) as temaScene;
        
        estrelas();
        //idTemaTxt.text = idTema.ToString();
       
        btnTema = GetComponent<Button>();
        verificaNotaMinima();
    
        
    }

    void verificaNotaMinima()
    {
        btnTema.interactable = false;
        if (requerNotaMinima == true)
        {
            int notaTemaAnterior = PlayerPrefs.GetInt("notaFinal_" + (idTema-1).ToString());
            if (notaTemaAnterior >= notaMinimaNecessaria)
            {
                btnTema.interactable = true;
            }
        }
        else
        {
            btnTema.interactable = true;
        }
    }
    public void selecionarTema () 
    {
        soundController.playbutton();
        PlayerPrefs.SetInt("idTema", idTema);
        PlayerPrefs.SetInt("min1Estrela", min1Estrela);
        PlayerPrefs.SetInt("min2Estrelas", min2Estrelas);

        temaScene.btnJogar.interactable = true;

        
    }

    public void estrelas() {

        foreach ( GameObject g in estrela)
        {
            g.SetActive(false);
            
        }

        int numEstrelas = 0;

        if (notaFinal == 10) 
        {
            numEstrelas = 3;
        }
        else if (notaFinal >= min2Estrelas) 
        {
            numEstrelas = 2;
        }
        else if (notaFinal >= min1Estrela)

        {
            numEstrelas = 1;
        }


        for (int i = 0; i < numEstrelas; i++) 
        {
            estrela[i].SetActive(true);
        }

    }

  
}
