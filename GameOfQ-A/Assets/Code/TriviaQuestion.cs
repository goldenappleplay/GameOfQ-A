using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TriviaQuestion
{
    public string category;
    public string type;
    public string difficulty;
    public string question;
    public string correct_answer;
    public string[] incorrect_answers;
}
