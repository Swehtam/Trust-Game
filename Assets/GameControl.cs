using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public PlayerControl player1;
    public PlayerControl player2;
    public Text roundLog;
    private string roundText;
    private bool player1Decision;

    // Update is called once per frame
    void Update()
    {
        roundLog.text = roundText;
    }

    //if action is:
    //true - cooperate
    //false - cheat
    //-------------------
    //if player is:
    //true - player1
    //false - player2
    public void RoundDecision(bool action, bool player)
    {

    }
}
