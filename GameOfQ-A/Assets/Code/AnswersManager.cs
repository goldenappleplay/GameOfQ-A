using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswersManager : MonoBehaviour
{
    [SerializeField] private Button[] answerButtons;
    [SerializeField] private TextMeshProUGUI[] answerTexts;


    private TriviaQuestion currentQuestion;

    public void DisplayAnswers(TriviaQuestion question)
    {
        currentQuestion = question;

        List<string> allAnswers = new List<string>(question.incorrect_answers);
        allAnswers.Add(question.correct_answer);
        allAnswers = ShuffleList(allAnswers);

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < allAnswers.Count)
            {
                answerButtons[i].gameObject.SetActive(true);
                answerTexts[i].text = allAnswers[i];
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => OnAnswerSelected(allAnswers[i]));
            }
        }
    }

    private void OnAnswerSelected(string selectedAnswer)
    {
        if (selectedAnswer == currentQuestion.correct_answer)
        {
            Debug.Log("Correct Answer!");
            //Proceed to the next question or any other logic
        }
        else
        {
            Debug.Log("Wrong Answer!");
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
