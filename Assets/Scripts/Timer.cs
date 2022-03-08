using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    //Refrences
    private Text timeCounter;
    private TimeSpan timePlaying;

    //Variables
    private float elapsedTime;
    private bool timerGoing;

    private void Awake()
    {
        //Getting the refrences
        timeCounter = GetComponent<Text>();
    }

    private void Start()
    {
        timeCounter.text = "00 : 00 : 00";
        timerGoing = false;

        BeginTimer();
    }

    private void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.unscaledDeltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
