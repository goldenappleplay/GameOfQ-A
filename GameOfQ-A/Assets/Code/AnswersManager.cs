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
                answerButtons[i].onClick.AddListener(() => OnAnswerSelected(allAnswers[index]));
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnAnswerSelected(string selectedAnswer)
    {
        if (selectedAnswer == currentQuestion.correct_answer)
        {
            Debug.Log("Correct Answer!");
            bool isCorrect = selectedAnswer == currentQuestion.correct_answer;
            questionDisplay.PlayerAnswered(questionDisplay.currentPlayer, isCorrect);
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
