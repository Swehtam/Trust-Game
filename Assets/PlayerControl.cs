using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public int playerNumb;
    public Text playerScore;
    public GameControl gameControl;
    public Button cooperateButton;
    public Button cheatButton;

    private int score;
    private PlayerDecision player;

    public class PlayerDecision
    {
        private int number; //Player Number
        private bool decision; //True if the player decided to cooperate
                               //False if the player doesn't
        private bool roundDecis; //True if the player already chose an option on this roud
                                 //False if the player doesn't
        public PlayerDecision(int num)
        {
            this.number = num;
        }

        public int PlayerNumb // property
        {
            get { return number; }
        }

        public bool Decision // property
        {
            get { return decision; }
            set { decision = value; }
        }
        
        public bool RoundDecision // property
        {
            get { return roundDecis; }
            set { roundDecis = value; }
        }
    }

    private void Awake()
    {
        player = new PlayerDecision(playerNumb);
        gameControl.InstancePlayerD(player);
    }

    void Update()
    {
        playerScore.text = score.ToString();
    }

    public void Cooperate()
    {
        player.Decision = true;
        player.RoundDecision = true;
        StartCoroutine(DisableButtons());
    }

    public void Cheat()
    {
        player.Decision = false;
        player.RoundDecision = true;
        StartCoroutine(DisableButtons());
    }

    public IEnumerator DisableButtons()
    {
        yield return new WaitForSeconds(0.05f);
        cooperateButton.interactable = false;
        cheatButton.interactable = false;
    }

    public void UpdateScore(int value)
    {
        score += value;
        cooperateButton.interactable = true;
        cheatButton.interactable = true;
    }
}
