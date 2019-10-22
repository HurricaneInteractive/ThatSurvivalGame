using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    private readonly int maxTime = 23;

    public int dayCount = 1;
    public int curTime = 20;

    // Number of seconds a hour lasts
    public float intervalTime = 5.0f;
    public TextMeshProUGUI clockText;

    // Update is called once per frame
    void Start()
    {
        clockText.text = GetCurrentUITime();
        InvokeRepeating("IncrementHour", intervalTime, intervalTime);
    }

    void IncrementHour()
    {
        if (curTime == maxTime)
        {
            curTime = 0;
            dayCount++;
        }
        else
        {
            curTime = curTime += 1;
        }

        clockText.text = GetCurrentUITime();
    }

    public string GetCurrentUITime()
    {
        return GetTimeAsString(curTime);
    }

    public int GetCurrentTime()
    {
        return curTime;
    }

    string GetTimeAsString(int currentTime)
    {
        string prefix = "";
        string suffix = ":00";

        if (currentTime < 10)
        {
            prefix = "0";
        }

        return prefix + currentTime.ToString() + suffix;
    }

    public float GetDayLength() {
        return intervalTime * 24;
    }
}
