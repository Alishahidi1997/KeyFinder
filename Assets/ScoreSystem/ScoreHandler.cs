using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreHandler : MonoBehaviour
{

    private int score = 0;

    private TMP_Text scoreBoard;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    void Start()
    {
        scoreBoard = this.GetComponent<TextMeshProUGUI>();
        scoreBoard.text = $"Key Found: {score}";
    }

    public void updateScore()
    {
        score += 1;
        scoreBoard.text = $"Key Found: {score}";
    }
}
