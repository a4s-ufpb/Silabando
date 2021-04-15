using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThemeScene : MonoBehaviour
{
    public Button buttonPlay;

    [Header ("Configuração da paginação")]
    public GameObject [] buttonPages;
    public GameObject[] themesPanels;
    private bool activePagesButton;
    private int pageID;
    private SoundController soundController;

    void Start()
    {
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        OnOffPanelButtons();
    }
    void OnOffPanelButtons()
    {
        buttonPlay.interactable = false;

        foreach (GameObject p in themesPanels) 
        {
            p.SetActive(false);
        }
        
        themesPanels[0].SetActive(true);
        
        if (themesPanels.Length > 1) activePagesButton = true;
    
        else activePagesButton = false;
         
        foreach(GameObject b in buttonPages) b.SetActive(activePagesButton);
    }
    public void PlayGame ()
    {
        soundController.ButtonSound();
     
        int sceneID = PlayerPrefs.GetInt("themeID");

        if(sceneID != 0) SceneManager.LoadScene(sceneID.ToString());
    }
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