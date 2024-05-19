using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class QuestionDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private AnswersManager answerManager;

    private List<TriviaQuestion> questions = new List<TriviaQuestion>();
    private int currentQuestionIndex = 0;


    [SerializeField] private TextMeshProUGUI scoreText; // Text object to display the score
    private int score = 0; // Field to store the player's score


    // Start is called before the first frame update
    void Start()
    {
        if (questions.Count > 0)
        {
            DisplayQuestion(questions[currentQuestionIndex]);
        }
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;

    }

    public void DisplayQuestion(TriviaQuestion question)
    {
        questionText.text = question.question;
        answerManager.DisplayAnswers(question);
    }

    public void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
        {
            DisplayQuestion(questions[currentQuestionIndex]);
        }
        else
        {
            Debug.Log("End of questions!");
        }
    }

    public void SetQuestions(List<TriviaQuestion> newQuestions)
    {
        questions = newQuestions;
        currentQuestionIndex = 0;
        score = 0;
        DisplayQuestion(questions[currentQuestionIndex]);
        UpdateScoreText();
    }

    internal void RestartGame()
    {
        currentQuestionIndex = 0;
        score = 0;
        if (questions.Count > 0)
        {
            DisplayQuestion(questions[currentQuestionIndex]);
        }
        UpdateScoreText();
    }
}
