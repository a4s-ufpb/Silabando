using System;
using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThemeInfo : MonoBehaviour
{
    private ThemeScene themeScene;

    [Header ("Identificação do tema")]
    public int themeID;
    public bool requiresMinPoints;
    public int minPointsNecessary;
   
   
    [Header ("Configuração do botão")] 
    public Text textThemeID;
    public GameObject[] star;

    [Header ("Configuração das estrelas")] 
    public int minOneStar, minTwoStars;
   
    private int finalPoints;

    private Button themeButton;

    private SoundController soundController;

    public static ThemeInfo themeInfo;
    internal int pointsFromPreviousTheme;

    void Start()
    {
        
        themeInfo = this;
        
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        
        finalPoints = PlayerPrefs.GetInt("finalScore_" + themeID.ToString());

        themeScene = FindObjectOfType (typeof(ThemeScene)) as ThemeScene;
        
        Stars();

        textThemeID.text = themeID.ToString();
       
        themeButton = GetComponent<Button>();

        VerifyMinPoints();

    
    }
    public void VerifyMinPoints()
    {
        themeButton.interactable = false;

        if (requiresMinPoints == true)
        {
            int pointsFromPreviousTheme = PlayerPrefs.GetInt("finalScore_" + (themeID-1).ToString());

            if (pointsFromPreviousTheme >= minPointsNecessary) themeButton.interactable = true;
        }
        else
        {
            themeButton.interactable = true;
        }
    }
    public void SelectTheme () 
    {
        soundController.ButtonSound();
        
        PlayerPrefs.SetInt("themeID", themeID);
        PlayerPrefs.SetInt("minOneStar", minOneStar);
        PlayerPrefs.SetInt("minTwoStars", minTwoStars);

        themeScene.buttonPlay.interactable = true;
        
    }

    public void Stars() {

        foreach ( GameObject g in star)
        {
            g.SetActive(false);
            
        }

        int numEstrelas = 0;

        if (finalPoints == 10) 
        {
            numEstrelas = 3;
        }
        else if (finalPoints >= minTwoStars) 
        {
            numEstrelas = 2;
        }
        else if (finalPoints >= minOneStar)

        {
            numEstrelas = 1;
        }


        for (int i = 0; i < numEstrelas; i++) 
        {
            star[i].SetActive(true);
        }

    }

  
}
