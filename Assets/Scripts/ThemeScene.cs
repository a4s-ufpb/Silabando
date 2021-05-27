using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for configuring the pagination of the challenge levels.
/// </summary>
public class ThemeScene : MonoBehaviour
{
    public Button buttonPlay;

    private bool activePagesButton;
    private int pageID;
    private SoundController soundController;

    /// <summary>
    /// This header is responsible for configuring the scene objects.
    /// </summary>
    [Header ("PAGING CONFIGURATION")]
    public GameObject [] buttonPages;
    public GameObject[] themesPanels;
    
    /// <summary>
    /// This function enables only one panel at a time.
    /// </summary>
    void Start()
    {
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        OnOffPanelButtons();
    }

    /// <summary>
    /// This function is responsible for activating / deactivating the scene panels.
    /// </summary>
    
    void OnOffPanelButtons()
    {
        buttonPlay.interactable = false;

        foreach (GameObject p in themesPanels) p.SetActive(false);
        themesPanels[0].SetActive(true);

        if (themesPanels.Length > 1) activePagesButton = true;
        else activePagesButton = false;
         
        foreach(GameObject b in buttonPages) b.SetActive(activePagesButton);
    }

    /// <summary>
    /// This function is responsible for taking the scene corresponding to the level to be played.
    /// </summary>
    public void PlayGame ()
    {
        soundController.ButtonSound();
     
        int sceneID = PlayerPrefs.GetInt("themeID");
        if(sceneID != 0) SceneManager.LoadScene(sceneID.ToString());
    }

    /// <summary>
    /// This function is responsible for counting the number of pages 
    /// and when it reaches the end, it returns to the beginning.
    /// </summary>
    /// <param name="i">Number of pages</param>
    public void PageButton (int i)
    {
        soundController.ButtonSound();
        pageID += i;

        if (pageID < 0) pageID = themesPanels.Length - 1;

        else if (pageID >= themesPanels.Length) pageID = 0;
        buttonPlay.interactable = false;
    
        foreach (GameObject p in themesPanels) p.SetActive(false);
        themesPanels[pageID].SetActive(true);
    }
}