using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoutineObject
{
    [Range(0, 23)]
    public int at;
    public GameObject interestPoint;

    public int GetAt() { return at; }
    public GameObject GetInterestPoint() { return interestPoint; }
}