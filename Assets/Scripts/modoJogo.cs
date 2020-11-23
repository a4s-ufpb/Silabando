using System;
using System.Net.Mime;
using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modoJogo : MonoBehaviour
{
    [Header ("Configuração dos textos")]
    public Text perguntaTxt;
    public Image perguntaIMG;
    public Text respostaTxt;

    [Header ("Configuração dos textos das alternativas")]
    public Text txtA;
    public Text txtB;
    public Text txtC;


    [Header ("Configuração da barra")]
    public GameObject barraTempo;

    [Header ("Configuração dos botões")]
    public Button[] botoes;
    public Color corAcerto;
    public Color corErro;

    [Header ("Configuração do modo de Jogo")]
    public bool perguntasComIMG;
    public bool jogarComTempo;
    public bool mostrarCorreta;
    public bool utilizarAlternativas;
    public float tempoResponder;
    public int qtdPiscar;
    
    [Header ("Configuração dos Painéis")]
    public GameObject [] paineis;
    public GameObject [] estrela;

    [Header ("Configuração das perguntas")]
    public string [] preencherCorreta;
    public string [] perguntas;
    public Sprite [] perguntasIMG;
    public string [] correta;

    [Header ("Configuração das alternativas")]
    public String [] AlternativasA;
    public String [] AlternativasB;
    public String [] AlternativasC;

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
        else
        {
      
            perguntaTxt.gameObject.SetActive(true);
            respostaTxt.gameObject.SetActive(false);

            perguntaTxt.text = perguntas[idResponder];
            respostaTxt.text = preencherCorreta[idResponder];

        }
            
        if (utilizarAlternativas == true)
        {
            txtA.text = AlternativasA[idResponder];
            txtB.text = AlternativasB[idResponder];
            txtC.text = AlternativasC[idResponder];
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
        completarPalavra();

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
            else
            {
                perguntaTxt.text = perguntas[idResponder];
                respostaTxt.text = preencherCorreta[idResponder];

            }
                
            if (utilizarAlternativas == true)
            {
                txtA.text = AlternativasA[idResponder];
                txtB.text = AlternativasB[idResponder];
                txtC.text = AlternativasC[idResponder];
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