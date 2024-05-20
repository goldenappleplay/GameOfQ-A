using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Net;

public class AnswersManager : MonoBehaviour
{
    [SerializeField] private Button[] answerButtons;
    [SerializeField] private TextMeshProUGUI[] answerTexts;

    private TriviaQuestion currentQuestion;
    [SerializeField] private QuestionDisplay questionDisplay;

    private bool player1Answered;
    private bool player2Answered;

    public void DisplayAnswers(TriviaQuestion question)
    {
        currentQuestion = question;

        List<string> allAnswers = new List<string>(question.incorrect_answers);
        allAnswers.Add(question.correct_answer);
        allAnswers = ShuffleList(allAnswers);

        //question.incorrect_answers.ToList().ForEach(answer => Debug.Log("iskam da vidq otgovorite: " + answer));

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < allAnswers.Count)
            {
                int index = i;  // Capture the current value of i
                answerButtons[i].gameObject.SetActive(true);
                answerTexts[i].text = WebUtility.HtmlDecode(allAnswers[i]);
                answerButtons[i].onClick.RemoveAllListeners();
                // Add listener for Player 1
                answerButtons[i].onClick.AddListener(() => OnAnswerSelected(questionDisplay.player1, allAnswers[index]));
                // Add listener for Player 2 (assume separate button or input)
                answerButtons[i].onClick.AddListener(() => OnAnswerSelected(questionDisplay.player2, allAnswers[index]));

            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnAnswerSelected(Player player, string selectedAnswer)
    {
        if (selectedAnswer == currentQuestion.correct_answer)
        {
            Debug.Log("Correct Answer!");
            bool isCorrect = selectedAnswer == currentQuestion.correct_answer;
            questionDisplay.PlayerAnswered(player, selectedAnswer, isCorrect);
            //questionDisplay.AddScore(100);
            //questionDisplay.NextQuestion();
            //Proceed to the next question or any other logic
        }
        else
        {
            Debug.Log("Wrong Answer!");
            questionDisplay.RestartGame();
            // Handle wrong answer, maybe restart the game or reduce lives
        }
    }

    private List<T> ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = UnityEngine.Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }
}
