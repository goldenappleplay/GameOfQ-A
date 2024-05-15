using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TriviaResponse
{
    public int response_code;
    public TriviaQuestion[] results;
}
