using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlaySound : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonPlay);
    }

    private void ButtonPlay()
    {
        GameMode.gameMode.PlayButtonSound();
    }
}
