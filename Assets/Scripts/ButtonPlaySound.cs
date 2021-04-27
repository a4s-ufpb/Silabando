using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for adding a click event
/// on the button to play the audio in the "Sílabas" challenge.
/// </summary>
public class ButtonPlaySound : MonoBehaviour
{
    /// <summary>
    /// This method adds a "listener" to the button.
    /// </summary>
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonPlay);
    }

    /// <summary>
    /// This method calls the function in the script "GameMode" 
    /// which is responsible for taking the position of the audio 
    /// referring to the current state of the player's question.
    /// </summary>
    private void ButtonPlay()
    {
        GameMode.gameMode.PlayButtonSound();
    }
}
