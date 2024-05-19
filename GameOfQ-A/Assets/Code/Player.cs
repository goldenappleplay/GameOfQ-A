using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name { get; private set; }
    public int Score { get; private set; }
    public bool HasAnswered { get; private set; }
    public bool IsCorrect { get; private set; }

    public Player(string name)
    {
        this.Name = name;
        this.Score = 0;
        this.HasAnswered = false;
        this.IsCorrect = false;
    }

    public void AddScore(int points)
    {
        this.Score += points;
    }
    public void ResetScore()
    {
        this.Score = 0;
    }

    public void SetAnswer(bool isCorrect)
    {
        this.HasAnswered = true;
        this.IsCorrect = isCorrect;
    }

    public void ResetAnswer()
    {
        this.HasAnswered = false;
        this.IsCorrect = false;
    }
}
