using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routine : MonoBehaviour
{

    private TimeManager timeManager;
    private int oldTime;
    private GameObject interestPoint;

    public RoutineObject[] routine;
    public float walkSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = new TimeManagerScript().script;
        oldTime = timeManager.GetCurrentTime();
    }

    // Update is called once per frame
    void Update()
    {
        int currentTime = timeManager.GetCurrentTime();

        if (routine.Length > 0 && oldTime != currentTime)
        {
            for (int i = 0; i < routine.Length; i++)
            {
                RoutineObject currentRoutine = routine[i];
                if (currentRoutine.GetAt() == timeManager.GetCurrentTime())
                {
                    interestPoint = currentRoutine.GetInterestPoint();
                }
            }

            oldTime = currentTime;
        }

        MoveToInterestPoint();
    }

    void MoveToInterestPoint()
    {
        if (interestPoint)
        {
            /**
             * @see https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html
             */
            float step = walkSpeed * Time.deltaTime;
            Vector3 destination = new Vector3(interestPoint.transform.position.x, transform.position.y, interestPoint.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, destination, step);

            if (Vector3.Distance(transform.position, interestPoint.transform.position) < 0.001f)
            {
                interestPoint = null;
            }
        }
    }
}
