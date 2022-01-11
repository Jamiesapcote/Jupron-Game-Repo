using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    //public varables 
    public float timeLimit;
    public string gameOverScene;

    private float startTime;
     private Text timerDisplay;

     void Start()
    {
        //get our text complant so we can edit the text each frame
        timerDisplay = GetComponent<Text>();
        startTime = Time.time;
    }

     void Update()
    {
        //calculate how much time has past
        float timePassed = Time.time - startTime;

        //Disply time since start
        timerDisplay.text = timePassed.ToString("0.00");
        if (timePassed >= timeLimit)
        {
            SceneManager.LoadScene(gameOverScene);
        }
    }
}
