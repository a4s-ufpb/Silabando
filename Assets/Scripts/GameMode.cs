using System;
using System.Net.Mime;
using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// This class configure the mode of the game, the questions and answers;
/// </summary>
public class GameMode : MonoBehaviour
{

    [Header ("GAME MODE")]
    public bool questionsWithImages;
    public bool optionsWithImages;
    public bool playWithTime;
    public float timeToAnswer;

    [Header ("OBJECTS OF QUESTIONS")]
    public Text textQuestion; 
    public Text answerText;
    public Image questionImage;

    [Header ("OBJECTS OF OPTIONS")]
    public Text textOptionA;    
    public Text textOptionB;    
    public Text textOptionC;

    [Header ("OBJECTS OF OPTIONS WITH IMAGE")]
    public Image [] optionWithImage;  

    [Header ("IMAGES OF OPTIONS")]
    public Image optionImageA;
    public Image optionImageB;

    [Header ("OBJECT OF TIME BAR")]
    public GameObject timeBar;

    [Header ("BUTTONS OF OPTIONS")]
    public Button [] optionButton;
    public Color colorRightQuestion;
    public Color colorWrongQuestion;

    [Header ("SHOWING CORRECT")]
    public bool usingOptions;
    public bool showCorrect;
    public int qttTimesOfButtonFlashing;
    
    [Header ("PANELS OF PLAY AND SCORE")]
    public GameObject [] panels;

    [Header ("OFF STARS OFF SCORE")]
    public GameObject [] star;

    [Header ("QUESTIONS")]
    public string [] questions;
    public Sprite [] questionsImage;

    [Header ("OPTIONS")]
    public String [] optionA;
    public String [] optionB;
    public String [] optionC;
    public Sprite [] optionWithImageA;
    public Sprite [] optionWithImageB;

    [Header ("CORRECT ANSWERS")]
    public string [] correct;
    public string [] fillCorrect;
    
    [SerializeField]
    public AudioClip [] audioQuestion;
    private AudioSource audioSource;    

    public static GameMode gameMode;

    private int themeID;
    private int answerID;
    private int minOneStar;
    private int minTwoStars;
    private int numberOfStars;
    private int buttonCorrectID;    
    private float qttCorrectAnswers;
    private float finalScore;
    private float questionValue;
    private float timePercentage;
    private float countTime;
    private bool showingCorrect;
    private SoundController soundController;

    /// <summary>
    /// This function starts any inicial configurations of the game.
    /// </summary>
    void Start()
    {
        gameMode = this;
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        audioSource = GetComponent<AudioSource>();
        timeBar.SetActive(false);
        themeID = PlayerPrefs.GetInt("themeID");
        CreateQuestionsList();
        ControlTimeBar();
        minOneStar = PlayerPrefs.GetInt("minOneStar");
        minTwoStars = PlayerPrefs.GetInt("minTwoStars");
        questionValue = 10 / (float)questions.Length; 
        panels[0].SetActive(true);
        panels[1].SetActive(false);
    }
    /// <summary>
    /// This function is responsable for play the audio of the word on challenge "Sílabas".
    /// </summary>
    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(audioQuestion[answerID]);
    }

    /// <summary>
    /// This function is responsable for update the time bar if the game mode is configured to play with time.
    /// </summary>
    void Update()
    {
        if (playWithTime == true && showingCorrect == false) 
        {
            countTime += Time.deltaTime;
            ControlTimeBar();

            if (countTime >= timeToAnswer) NextQuestion();
        }
        
    }

    /// <summary>
    /// This function ís responsable for create a list of questions and verify if the question is text or image.
    /// </summary>   
    public void CreateQuestionsList() 
    {
        if(questionsWithImages == true)
        { 
            questionImage.sprite = questionsImage[answerID];
        }
        else if (optionsWithImages == true)
        {
            textQuestion.text = questions[answerID];
            optionImageA.sprite = optionWithImageA[answerID];
            optionImageB.sprite = optionWithImageB[answerID];
            textQuestion.gameObject.SetActive(true);
            answerText.gameObject.SetActive(false);
        }
        else
        {
            textQuestion.gameObject.SetActive(true);
            answerText.gameObject.SetActive(false);
            textQuestion.text = questions[answerID];
            answerText.text = fillCorrect[answerID];
        }
        if (usingOptions == true && optionsWithImages == false)
        {
            textOptionA.text = optionA[answerID];
            textOptionB.text = optionB[answerID];
            textOptionC.text = optionC[answerID];
        }
    }

    /// <summary>
    /// This function is responsable for process the answer of the player.
    /// </summary>
    /// <param name="option">Configure the buttons of options to check the correct answer.</param>
    public void Answer (string option) 
    {
        if (showingCorrect == true) 
        {
            return;
        }
        if (correct[answerID] == option) 
        {
            qttCorrectAnswers += 1;
            soundController.PlayAudioRightQuestion();
        }
        else
        {
            soundController.PlayAudioWrongQuestion();
        }
      
        switch(correct[answerID])
        {
            case "A":
                buttonCorrectID = 0;
                break;
            case "B":
                buttonCorrectID = 1;
                break;
            case "C":
                buttonCorrectID = 2;
                break;
        }

        if (optionsWithImages == false) 
        {
            CompleteWord();
        }
        if (showCorrect == true) 
        {
            foreach(Button b in optionButton)
            {
                b.image.color = colorWrongQuestion;
            }
            showingCorrect = true;
            optionButton[buttonCorrectID].image.color = colorRightQuestion;
            StartCoroutine("CorrectOption");
        }
        else
        {
            Invoke("NextQuestion()", 4.0f);
        }
    }

    /// <summary>
    /// This funcion is responsable for complete the word on challenge "Sílabas"
    /// </summary>
    void CompleteWord()
    {
        if (questionsWithImages == false)
        {
            textQuestion.gameObject.SetActive(false);
            answerText.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// This function call the next question
    /// </summary>
    public void NextQuestion()
    {
        answerID += 1;
        countTime = 0;

        EventSystem.current.SetSelectedGameObject(null);
        
        if (questionsWithImages == false)
        {
            textQuestion.gameObject.SetActive(true);
            answerText.gameObject.SetActive(false);
        }
        if (answerID < questions.Length)
        {
            CreateQuestionsList();
        }
        else
        {
            CalculeFinalScore();
        }

    }

    /// <summary>
    /// This function controls the time bar
    /// </summary>
    void ControlTimeBar ()
    {
        if (playWithTime == true)
        {
            timeBar.SetActive(true);
        }
        timePercentage = ((countTime - timeToAnswer) / timeToAnswer) * -1;

        if (timePercentage < 0) 
        { 
            timePercentage = 0;
        }
        timeBar.transform.localScale = new Vector3 (timePercentage, 1, 1);
    }

    /// <summary>
    /// This functions is the responsable for calculate the final score of the level
    /// </summary>
    void CalculeFinalScore() 
    {
        finalScore = Mathf.RoundToInt(questionValue * qttCorrectAnswers);

        if (finalScore > PlayerPrefs.GetInt("finalScore_" + themeID.ToString()))    PlayerPrefs.SetInt("finalScore_" + themeID.ToString(), (int)finalScore);
        
        if (finalScore == 10) numberOfStars = 3;  

        else if (finalScore >= minTwoStars) numberOfStars = 2;

        else if (finalScore >= minOneStar) numberOfStars = 1;
      
        foreach ( GameObject g in star) g.SetActive(false);
        
        for (int i = 0; i < numberOfStars; i++) star[i].SetActive(true);

        panels[0].SetActive(false);
        panels[1].SetActive(true);

        soundController.Stars();

    }
    /// <summary>
    /// Wait any seconds to call another question
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitNext()
    {
        yield return new WaitForSeconds(0.5f);
    }
    
    /// <summary>
    /// This funcion shows the button flashing when the questions is correct or wrong
    /// </summary>
    /// <returns></returns>
    IEnumerator CorrectOption () 
    {
        for (int i = 0; i < qttTimesOfButtonFlashing; i++)
        {
            optionButton[buttonCorrectID].image.color = colorRightQuestion;
            yield return new WaitForSeconds(0.2f);

            optionButton[buttonCorrectID].image.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
        foreach(Button b in optionButton)
        {
            b.image.color = Color.white;
        }
        showingCorrect = false;

        NextQuestion();
    }
 
}