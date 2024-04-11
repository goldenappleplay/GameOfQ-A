using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class TriviaAPI : MonoBehaviour
{
    // The API URL from the Open Trivia Database
    private string apiURL = "https://opentdb.com/api.php?amount=50&category=9&difficulty=medium&type=multiple";

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
                //proces
            }
        }
    }
}
