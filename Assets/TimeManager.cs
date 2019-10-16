using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private readonly int maxTime = 23;

    //public int startingTime = 20;
    public int curTime = 20;

    // Number of seconds a hour lasts
    public float intervalTime = 5.0f;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("IncrementHour", intervalTime, intervalTime);
    }

    void IncrementHour()
    {
        if (curTime == maxTime)
        {
            curTime = 0;
        }
        else
        {
            curTime = curTime += 1;
        }

        Debug.Log(GetTimeAsString(curTime));
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
}
