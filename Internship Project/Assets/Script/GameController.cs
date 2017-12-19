using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;

    private List<GameObject> answerButtonGO = new List<GameObject>();

    public AnswerButtonPool answerButtonPool;
    public Text questionText;
    public Text scoreText;
    public Text timeText;
    public Transform parentsPanel;
    public GameObject questionPanel;
    public GameObject endPanel;
    

    // Use this for initialization
    void Start () {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimit;
        UpdatedTimeText();

        playerScore = 0;
        questionIndex = 0;

        ShowQuestion();
        isRoundActive = true;
        
	}

    private void ShowQuestion()
    {
        RemoveAnswerButton();
        QuestionData questionData = questionPool[questionIndex];
        questionText.text = questionData.questionText;

        //for showing the button
        for(int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject asbGO = answerButtonPool.GetObject();
            asbGO.transform.SetParent(parentsPanel);
            answerButtonGO.Add(asbGO);

            AnswerButton answerButton = asbGO.GetComponent<AnswerButton>();
            answerButton.SetUp(questionData.answers[i]);
        }
    }

    private void RemoveAnswerButton()
    {
        while(answerButtonGO.Count > 0)
        {
            answerButtonPool.ReturnObject(answerButtonGO[0]);
            answerButtonGO.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if(isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            scoreText.text = "Score: " + playerScore.ToString();
        }

        // changed this lower part for future changes regarding the system, if slight changes are needed
        if(questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }
        else
        {
            EndRound();
        }
    }

    public void EndRound()
    {
        isRoundActive = false;
        questionPanel.SetActive(false);
        endPanel.SetActive(true);
    }
    
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main");
    }
	
    private void UpdatedTimeText()
    {
        timeText.text = "Time: " + timeRemaining.ToString("f0");
    }
	// Update is called once per frame
	void Update () {
		
        if(isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdatedTimeText();
        }

        if(timeRemaining<=0)
        {
            EndRound();
        }
	}
}
