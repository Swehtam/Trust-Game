using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameControl : MonoBehaviour
{
    public PlayerControl player1;
    public PlayerControl player2;
    public Text roundLog;
    public Text endText;

    private string roundText;
    private int maxRounds;
    private PlayerControl.PlayerDecision playerD1;
    private PlayerControl.PlayerDecision playerD2;

    private void Start()
    {
        System.Random random = new System.Random();
        maxRounds = random.Next(5, 11);
    }

    // Update is called once per frame
    void Update()
    {
        if(maxRounds != 0)
        {
            CheckForDecision();
        }
        else
        {
            endText.text = "Game over";
            StartCoroutine(player1.DisableButtons());
            StartCoroutine(player2.DisableButtons());
        }
        
    }
    
    public void InstancePlayerD(PlayerControl.PlayerDecision playerD)
    {
        if (playerD.PlayerNumb == 1)
        {
            playerD1 = playerD;
            
        }
        else
        {
            playerD2 = playerD;
        }
    }

    private void CheckForDecision()
    {
        if (playerD1.RoundDecision && playerD2.RoundDecision) //Both of them made a decision
        {
            int scoreP1 = 0;
            int scoreP2 = 0;

            roundLog.text = "Player 1: ";
            if (playerD1.Decision) //Cooperated
            {
                roundLog.text += "Cooperated";
                scoreP1 -= 1;
                scoreP2 += 3;
            }
            else //Cheated
            {
                roundLog.text += "Cheated";
            }

            roundLog.text += "\nPlayer 2: ";
            if (playerD2.Decision) //Cooperated
            {
                roundLog.text += "Cooperated";
                scoreP1 += 3;
                scoreP2 -= 1;
            }
            else //Cheated
            {
                roundLog.text += "Cheated";
            }

            roundLog.text += "\n\n" + scoreP1 + "/" + scoreP2;

            playerD1.RoundDecision = false;
            playerD2.RoundDecision = false;
            StartCoroutine(UpdateScores(scoreP1, scoreP2));            
        }
    }

    private IEnumerator UpdateScores(int scoreP1, int scoreP2)
    {
        yield return new WaitForSeconds(1);
        player1.UpdateScore(scoreP1);
        player2.UpdateScore(scoreP2);
        
        maxRounds -= 1;
    }
}
