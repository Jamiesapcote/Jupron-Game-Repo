using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
   public float currentTime = 0f;
    public float startingtime = 10f;

    [SerializeField] Text countDownText;

    private void Start()
    {
        currentTime = startingtime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
        }

    }

}
