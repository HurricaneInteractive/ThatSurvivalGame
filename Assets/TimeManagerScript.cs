using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerScript
{
    private GameObject timeManager;
    public TimeManager script;

    public TimeManagerScript() {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager");
        script = (TimeManager)timeManager.GetComponent(typeof(TimeManager));
    }
}