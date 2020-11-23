using System;
using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoTema : MonoBehaviour
{
    private temaScene temaScene;
    [Header ("Identificação do tema")]
    public int idTema;
   
   
    [Header ("Configuração do botão")] 
    public Text idTemaTxt;
    public GameObject[] estrela;

    [Header ("Configuração das estrelas")] 
    public int min1Estrela, min2Estrelas;
   
    private int notaFinal;
   
    void Start()
    {
        notaFinal = PlayerPrefs.GetInt("notaFinal_" + idTema.ToString());

        temaScene = FindObjectOfType (typeof(temaScene)) as temaScene;

        //idTemaTxt.text = idTema.ToString();
        
        estrelas();
        
    }

    public void selecionarTema () 
    {
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
