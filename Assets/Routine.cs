using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class Routine : MonoBehaviour
{

    GameObject timeManager;
    public RoutineObject[] routine;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager");
        TimeManager timeManagerScript = (TimeManager)timeManager.GetComponent(typeof(TimeManager));
        Debug.Log(timeManagerScript.GetCurrentUITime());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
