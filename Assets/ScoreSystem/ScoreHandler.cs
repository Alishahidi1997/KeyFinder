using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ScoreHandler : MonoBehaviour
{

    private int score = 0;
    private int numberOfKeys = 3; 

    private TMP_Text scoreBoard;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public int NumberOfKeys
    {
        get { return numberOfKeys; }
    }

    public void Awake()
    {
        scoreBoard = this.GetComponent<TextMeshProUGUI>();
        SetScoreToScoreBoard();
    }

 
    public void updateScore()
    {
        score += 1;
        SetScoreToScoreBoard();
    }

    public void SetScoreToScoreBoard()
    {
        scoreBoard.text = $"Key Found: {score} | Door is locked";
        if (score == numberOfKeys)
        {
            scoreBoard.text = $"Key Found: {score} | Door is unlocked";
        }
    }

    public void AreAllKeysFound()
    {
        Debug.Log("Numb : " + numberOfKeys + " " + score);
        if (score == numberOfKeys)
        {
            SceneManager.LoadScene("Finish");
        }
    }
}
