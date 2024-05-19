using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;


public class TriviaAPI : MonoBehaviour
{
    // The API URL from the Open Trivia Database
    private string apiURL = "https://opentdb.com/api.php?amount=50&category=17&type=multiple";

    public QuestionDisplay questionDisplay;

    private void Start()
    {
        StartCoroutine(GetTriviaQuestions());
    }

    private IEnumerator GetTriviaQuestions()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiURL))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                string responseText = webRequest.downloadHandler.text;
                Debug.Log("Received JSON: " + responseText);  // Add this line
                ProcessTriviaResponse(responseText);
            }
        }
    }

    public  void ProcessTriviaResponse(string json)
    {
        //TriviaResponse triviaResponse = JsonUtility.FromJson<TriviaResponse>("{\"results\":" + json + "}");
        TriviaResponse triviaResponse = JsonUtility.FromJson<TriviaResponse>(json);

        if (triviaResponse == null || triviaResponse.results == null)
        {
            Debug.LogError("Deserialized TriviaResponse is null.");
            return;
        }

        foreach (TriviaQuestion question in triviaResponse.results)
        {
            //string decodedQuestion = WebUtility.HtmlDecode(question.question);
            //string decodedCorrectAnswer = WebUtility.HtmlDecode(question.correct_answer);
            //List<string> decodedIncorrectAnswers = new List<string>();
            //foreach (string answer in question.incorrect_answers)
            //{
            //    decodedIncorrectAnswers.Add(WebUtility.HtmlDecode(answer));
            //}
            question.question = WebUtility.HtmlDecode(question.question);
            question.correct_answer = WebUtility.HtmlDecode(question.correct_answer);
            for (int i = 0; i < question.incorrect_answers.Length; i++)
            {
                question.incorrect_answers[i] = WebUtility.HtmlDecode(question.incorrect_answers[i]);
            }
            Debug.Log("Decoded Question: " + question.question);
            Debug.Log("Decoded Correct Answer: " + question.correct_answer);
            for (int i = 0; i < question.incorrect_answers.Length; i++)
            {
                Debug.Log("Decoded Incorrect Answer " + i + ": " + question.incorrect_answers[i]);

            }

        }

        if (triviaResponse.results.Length > 0)
        {
            questionDisplay.SetQuestions(new List<TriviaQuestion>(triviaResponse.results));
            //questionDisplay.DisplayQuestion(triviaResponse.results[0]);
        }
    }
}
