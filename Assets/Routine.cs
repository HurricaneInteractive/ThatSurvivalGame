using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class Routine : MonoBehaviour
{

    GameObject timeManager;
    TimeManager timeManagerScript;
    private int oldTime;

    public RoutineObject[] routine;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager");
        timeManagerScript = (TimeManager)timeManager.GetComponent(typeof(TimeManager));
        oldTime = timeManagerScript.GetCurrentTime();
    }

    // Update is called once per frame
    void Update()
    {
        int currentTime = timeManagerScript.GetCurrentTime();
        if (routine.Length > 0 && oldTime != currentTime)
        {
            for (int i = 0; i < routine.Length; i++)
            {
                RoutineObject currentRoutine = routine[i];
                if (currentRoutine.GetAt() == timeManagerScript.GetCurrentTime())
                {
                    MoveToInterestPoint(currentRoutine.GetInterestPoint());
                }
            }

            oldTime = currentTime;
        }
    }

    void MoveToInterestPoint(GameObject interestPoint)
    {
        //Vector3 position = interestPoint.transform.position;
        Debug.Log("Move to" + interestPoint);
    }
}
