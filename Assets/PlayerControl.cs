using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private int score;
    public Text playerScore;
    public GameControl gameControl;

    void Update()
    {
        playerScore.text = score.ToString();
    }

    public void Cooperate()
    {

    }

    public void Cheat()
    {

    }

    public void UpdateScore(int value)
    {
        score += value;
    }
}
