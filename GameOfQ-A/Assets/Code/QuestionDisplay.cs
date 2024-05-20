using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Net;

public class QuestionDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI playerTurnText;
    [SerializeField] private AnswersManager answerManager;

    private List<TriviaQuestion> questions = new List<TriviaQuestion>();
    private int currentQuestionIndex = 0;


    [SerializeField] private TextMeshProUGUI scoreText; // Text object to display the score
    private int score = 0; // Field to store the player's score

    public Player player1 { get; private set; }  // Make player1 public
    public Player player2 { get; private set; }  // Make player2 public

    //public Player currentPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player1 = new Player("Player 1");
        player2 = new Player("Player 2");
        //currentPlayer = player1;

        if (questions.Count > 0)
        {
            DisplayQuestion(questions[currentQuestionIndex]);
        }
        UpdateScoreText();
        //UpdatePlayerTurnText();
    }

  
    public void AddScore(Player player, int points)
    {
        player.AddScore(points);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{player1.Name}: {player1.Score} - {player2.Name}: {player2.Score}";
    }

    //private void UpdatePlayerTurnText()
    //{
    //    playerTurnText.text = $"Current Turn: {currentPlayer.Name}";
    //}

    public void DisplayQuestion(TriviaQuestion question)
    {
        questionText.text = WebUtility.HtmlDecode(question.question);
        answerManager.DisplayAnswers(question);
        ResetPlayersAnswers();
    }

    private void ResetPlayersAnswers()
    {
        player1.ResetAnswer();
        player2.ResetAnswer();
    }

    public void EvaluateAnswers()
    {
        if (player1.HasAnswered && player2.HasAnswered)
        {
            if (player1.IsCorrect)
            {
                AddScore(player1, 100);
            }
            if (player2.IsCorrect)
            {
                AddScore(player2, 100);
            }
            NextQuestion();
        }
    }

    public void PlayerAnswered(Player player, string selectedAnswer, bool isCorrect)
    {
        player.SetAnswer(isCorrect, selectedAnswer);
        EvaluateAnswers();
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
        player1.ResetScore();
        player2.ResetScore();
        DisplayQuestion(questions[currentQuestionIndex]);
        UpdateScoreText();
    }

    internal void RestartGame()
    {
        currentQuestionIndex = 0;
        player1.ResetScore();
        player2.ResetScore();
        if (questions.Count > 0)
        {
            DisplayQuestion(questions[currentQuestionIndex]);
        }
        UpdateScoreText();
    }
}
