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
        answerManager.DisplayAnswers(question);
    }

    public void SetQuestions(List<TriviaQuestion> newQuestions)
    {
        questions = newQuestions;
    }

    
}
