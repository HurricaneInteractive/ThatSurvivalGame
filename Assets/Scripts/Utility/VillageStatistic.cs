using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageStatistic
{
    private TimeManager timeManager = new TimeManagerScript().script;
    private float dayLength;
    private float decreasePerSecond;

    public float decreaseRate;
    public float currentValue;

    public VillageStatistic(float startingValue, float rate)
    {
        currentValue = startingValue;
        decreaseRate = rate;

        dayLength = timeManager.intervalTime;
        decreasePerSecond = rate / dayLength;
    }

    public void DecreaseStatistic()
    {
        currentValue = (float)Math.Round(currentValue - decreasePerSecond, 2);
    }

    public void UpdateDecreaseRateBy(float value)
    {
        decreaseRate += value;
        decreasePerSecond = decreaseRate / dayLength;
    }
}