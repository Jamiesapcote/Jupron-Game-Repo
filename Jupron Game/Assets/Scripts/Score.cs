using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreDisplay;

    private int scoreValue = 0;
    //fuction top add to the players score 
    //NOT automaticly called by unity - we need to call it ourselves in our code
    public void addScore(int toAdd)
    {
        //Update the numerical value of the score (ation 1)

        scoreValue = scoreValue + toAdd;

        //update display of the score based on the numerical
        scoreDisplay.text = scoreValue.ToString();
    }
}
