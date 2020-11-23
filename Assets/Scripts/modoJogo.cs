using System;
using System.Net.Mime;
using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modoJogo : MonoBehaviour
{
    [Header ("Configuração das Perguntas")]
    public Text perguntaTxt; 
    public Text respostaTxt;
    public Image perguntaIMG;

    [Header ("Configuração das alternativas")]
    public Text txtA;    
    public Text txtB;    
    public Text txtC;
    public Image [] alternativasIMG;    

    [Header ("Configuração das imagens das alternativas")]
    public Image imageA;
    public Image imageB;

    [Header ("Configuração da barra")]
    public GameObject barraTempo;

    [Header ("Configuração dos botões")]
    public Button[] botoes;
    public Color corAcerto;
    public Color corErro;

    [Header ("Configuração do modo de Jogo")]
    public bool perguntasComIMG;
    public bool alternativaComIMG;

    [Header ("Configuração jogar com tempo")]
    public bool jogarComTempo;
    public float tempoResponder;
   

    [Header ("Configuração exibindo correta")]
    public bool utilizarAlternativas;
    public bool mostrarCorreta;
     public int qtdPiscar;
    
    [Header ("Configuração dos Paineis")]
    public GameObject [] paineis;

    [Header ("Configuração das estrelas")]
    public GameObject [] estrela;

    [Header ("Configuração das perguntas")]
    public string [] perguntas;
    public Sprite [] perguntasIMG;

    [Header ("Configuração das alternativas")]
    public String [] alternativasA;
    public String [] alternativasB;
    public String [] alternativasC;
    public Sprite [] alternativaAComIMG;
    public Sprite [] alternativaBComIMG;

    [Header ("Configuração das respostas")]
    public string [] correta;
    public string [] preencherCorreta;
    

    private int idTema;
    private int idResponder;
    private int min1Estrela;
    private int min2Estrelas;
    private int nEstrelas;
    private int idBtnCorreto;    

    private float qtdAcertos;
    private float notaFinal;
    private float valorQuestao;
    private float percTempo;
    private float tempTime;
    
    private bool exibindoCorreta;

    void Start()
    {

        barraTempo.SetActive(false);
        idTema = PlayerPrefs.GetInt("idTema");
        
        montarListaPerguntas();
        controleBarraTempo();

        min1Estrela = PlayerPrefs.GetInt("min1Estrela");
        min2Estrelas = PlayerPrefs.GetInt("min2Estrelas");

        valorQuestao = 10 / (float)perguntas.Length; 

        paineis[0].SetActive(true);
        paineis[1].SetActive(false);
    }

    void Update()
    {
        if (jogarComTempo == true && exibindoCorreta == false) 
        {
            tempTime += Time.deltaTime;
            controleBarraTempo();

            if (tempTime >= tempoResponder) 
            {
                proximaPergunta();
            }
        }
        
    }

    public void montarListaPerguntas() 
    {
        if(perguntasComIMG == true)
        {
            perguntaIMG.sprite = perguntasIMG[idResponder];

        }
        else if (alternativaComIMG == true)
        {
            perguntaTxt.text = perguntas[idResponder];
            imageA.sprite = alternativaAComIMG[idResponder];
            imageB.sprite = alternativaBComIMG[idResponder];

            perguntaTxt.gameObject.SetActive(true);
            respostaTxt.gameObject.SetActive(false);
        }
        else
        {
      
            perguntaTxt.gameObject.SetActive(true);
            respostaTxt.gameObject.SetActive(false);

            perguntaTxt.text = perguntas[idResponder];
            respostaTxt.text = preencherCorreta[idResponder];

        }

        if (utilizarAlternativas == true && alternativaComIMG == false)
        {
            txtA.text = alternativasA[idResponder];
            txtB.text = alternativasB[idResponder];
            txtC.text = alternativasC[idResponder];
        }
    }

    public void responder (string alternativa) 
    {
        
        if (exibindoCorreta == true) 
        {
            return;
        }

        if (correta[idResponder] == alternativa) 
        {
            print("Acertou miseravi");
            qtdAcertos += 1;
           
        }
      
        switch(correta[idResponder])
        {
            case "A":
                idBtnCorreto = 0;
                break;
            case "B":
                idBtnCorreto = 1;
                break;
            case "C":
                idBtnCorreto = 2;
                break;
        }

        if (alternativaComIMG == false)
        {
            completarPalavra();
        }
        
        if (mostrarCorreta == true) 
        {
            foreach(Button b in botoes)
            {
                b.image.color = corErro;
            }
            exibindoCorreta = true;
            botoes[idBtnCorreto].image.color = corAcerto;
            StartCoroutine("alternativaCorreta");
        }
        else
        {
            proximaPergunta();
        }
    }

    void completarPalavra()
    {
        if (perguntasComIMG == false)
        {
            perguntaTxt.gameObject.SetActive(false);
            respostaTxt.gameObject.SetActive(true);

        }
    }

    public void proximaPergunta()
    {
        idResponder += 1;
        tempTime = 0;
        
        if (perguntasComIMG == false)
            {
                perguntaTxt.gameObject.SetActive(true);
                respostaTxt.gameObject.SetActive(false);

            }
            if (idResponder < perguntas.Length)
            {
                if(perguntasComIMG == true)
                {
                    perguntaIMG.sprite = perguntasIMG[idResponder];

                }
                else if (alternativaComIMG == true)
                {
                    perguntaTxt.text = perguntas[idResponder];
                    imageA.sprite = alternativaAComIMG[idResponder];
                    imageB.sprite = alternativaBComIMG[idResponder];

                    perguntaTxt.gameObject.SetActive(true);
                    respostaTxt.gameObject.SetActive(false);
                }
                else
                {
                    perguntaTxt.text = perguntas[idResponder];
                    respostaTxt.text = preencherCorreta[idResponder];

                }
                
            if (utilizarAlternativas == true && alternativaComIMG == false)
            {
                txtA.text = alternativasA[idResponder];
                txtB.text = alternativasB[idResponder];
                txtC.text = alternativasC[idResponder];
            }
        }
        else
        {
            calcularNotaFinal();
        }
    }

    void controleBarraTempo ()
    {
        if (jogarComTempo == true)
        {
            barraTempo.SetActive(true);
        }

        percTempo = ((tempTime - tempoResponder) / tempoResponder) * -1;

        if (percTempo < 0) 
        { 
            percTempo = 0;
        
        }

        barraTempo.transform.localScale = new Vector3 (percTempo, 1, 1);
    }

    void calcularNotaFinal() 
    {
        notaFinal = Mathf.RoundToInt(valorQuestao * qtdAcertos);

        if (notaFinal > PlayerPrefs.GetInt("notaFinal_" + idTema.ToString()))
        {
            PlayerPrefs.SetInt("notaFinal_" + idTema.ToString(), (int)notaFinal);
        }

        
        if (notaFinal == 10) 
        {
            nEstrelas = 3;
        }
        else if (notaFinal >= min2Estrelas) 
        {
            nEstrelas = 2;
        }
        else if (notaFinal >= min1Estrela)

        {
            nEstrelas = 1;
        }
      
        foreach ( GameObject g in estrela)
        {
            g.SetActive(false);
            
        }
      
               
        for (int i = 0; i < nEstrelas; i++) 
        {
            estrela[i].SetActive(true);
        }

        paineis[0].SetActive(false);
        paineis[1].SetActive(true);

    }

    IEnumerator alternativaCorreta () 
    {
        for (int i = 0; i < qtdPiscar; i++)
        {
            botoes[idBtnCorreto].image.color = corAcerto;
            yield return new WaitForSeconds(0.2f);
            botoes[idBtnCorreto].image.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
        foreach(Button b in botoes)
        {
            b.image.color = Color.white;
        }
        exibindoCorreta = false;
        proximaPergunta();
    }
}