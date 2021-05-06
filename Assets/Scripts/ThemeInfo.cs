using System;
using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for configuring the information for each theme.
/// </summary>
public class ThemeInfo : MonoBehaviour
{
    private ThemeScene themeScene;
    private int finalPoints;
    private Button themeButton;
    private SoundController soundController;

    public static ThemeInfo themeInfo;

    /// <summary>
    /// Each header is responsible for configuring an object in the game. 
    /// Some are configured manually in the scene.
    /// </summary>
    [Header ("THEME IDENTIFICATION")]
    public int themeID;
    public bool requiresMinPoints;
    public int minPointsNecessary;
   
    [Header ("BUTTON CONFIGURATION")] 
    public Text textThemeID;
    public GameObject[] star;

    [Header ("STARS CONFIGURATION")] 
    public int minOneStar, minTwoStars;
   
   /// <summary>
   /// This function is responsible for picking up objects and checking the 
   /// number of stars to be displayed on the level screen.
   /// It also checks the scene of the current theme.
   /// </summary>
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

    /// <summary>
    /// This function is responsible for checking the minimum number of
    ///  points to advance to the next level (if configured in the game mode).
    /// </summary>
    public void VerifyMinPoints()
    {
        themeButton.interactable = false;

        if (requiresMinPoints == true)
        {
            int pointsFromPreviousTheme = PlayerPrefs.GetInt("finalScore_" + (themeID-1).ToString());
            if (pointsFromPreviousTheme >= minPointsNecessary) themeButton.interactable = true;
        }
        else themeButton.interactable = true;
    }
    
    /// <summary>
    /// This function is responsible for selecting the theme to enable the "Play" button.
    /// </summary>
    public void SelectTheme () 
    {
        soundController.ButtonSound();
        
        PlayerPrefs.SetInt("themeID", themeID);
        PlayerPrefs.SetInt("minOneStar", minOneStar);
        PlayerPrefs.SetInt("minTwoStars", minTwoStars);

        themeScene.buttonPlay.interactable = true;
        
    }

    /// <summary>
    /// This function is responsible for enabling the number of stars 
    /// on the level screen, according to the score.
    /// </summary>
    public void Stars() {

        foreach ( GameObject g in star) g.SetActive(false);

        int numEstrelas = 0;

        if (finalPoints == 10) numEstrelas = 3;
        else if (finalPoints >= minTwoStars) numEstrelas = 2;
        else if (finalPoints >= minOneStar) numEstrelas = 1;

        for (int i = 0; i < numEstrelas; i++) star[i].SetActive(true);
    }  
}
