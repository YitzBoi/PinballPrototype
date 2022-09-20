using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int balls = 3;
    private int score = 0;
    private int multiplier = 1;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI ballsUI;
    [SerializeField] private TextMeshProUGUI multiplierUI;
    [SerializeField] private GameObject gameOverPanelUI;

    private const int MaxMultiplier = 20;

    // Update is called once per frame
    void Update()
    {
        if (AnyBallsLeft())
        {
            scoreUI.text = "Score: " + score.ToString();
            ballsUI.text = "Balls: " + balls.ToString();
            multiplierUI.text = "Multiplier: X" + multiplier.ToString();
        }
        else
        {
            scoreUI.enabled = false;
            ballsUI.enabled = false;
            multiplierUI.enabled = false;
            gameOverPanelUI.SetActive(true);
        }
    }

    public void LoseBall()
    {
        balls--;
    }

    public void AcquireBall()
    {
        balls++;
    }

    public bool AnyBallsLeft()
    {
        return balls > 0;
    }

    public void ModifyMultiplier(int newMultiplier)
    {
        multiplier += newMultiplier;

        multiplier = Math.Min(multiplier, MaxMultiplier);
    }

    public void AddToScore(int scoreAmount)
    {
        score += scoreAmount * multiplier;
    }
}
