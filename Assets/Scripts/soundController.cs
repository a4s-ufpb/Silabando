using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{

    public AudioSource audioMusic, audioFX;
    public AudioClip somAcerto, somErro, somBotao, vinheta3Estrelas;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }   
    void Start()
    {

        audioMusic.Play();
    }

    public void playAcerto()
    {
        audioFX.PlayOneShot(somAcerto);

    }

    public void playErro()
    {
        
        audioFX.PlayOneShot(somErro);
    }
    
    public void playbutton()
    {
        audioFX.PlayOneShot(somBotao);
    }

    public void estrelas()
    {
        audioFX.PlayOneShot(vinheta3Estrelas);
    }

}
