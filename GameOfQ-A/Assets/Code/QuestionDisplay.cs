using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class QuestionDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Button[] buttons;

    [SerializeField] private TextMeshProUGUI[] answers;

    private TriviaQuestion currentQuestion;
    private List<TriviaQuestion> questions = new List<TriviaQuestion>();


    // Start is called before the first frame update
    void Start()
    {
        if (questions.Count > 0)
        {
            DisplayQuestion(questions[0]);
        }
    }

    public void DisplayQuestion(TriviaQuestion question)
    {
        questionText.text = question.question;
    }

    public void SetQuestions(List<TriviaQuestion> newQuestions)
    {
        questions = newQuestions;
    }

    public void DisplayAnswers(TriviaQuestion question)
    {
        List<string> allAnswers = new List<string>(question.incorrect_answers);
        allAnswers.Add(question.correct_answer);
        allAnswers = ShuffleList(allAnswers);
    }

    private List<T> ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count-1; i > 0; i--)
        {
            int randomIndex = UnityEngine.Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }
}
