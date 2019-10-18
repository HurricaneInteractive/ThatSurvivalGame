using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    private TimeManager timeManager;

    public VillageStatistic morale;
    public float moraleStartingValue = 100.0f;
    public float moraleDecreaseRate = 1.0f;
    public float currentMorale;
    public float moraleIntervalTime;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = new TimeManagerScript().script;

        moraleIntervalTime = timeManager.intervalTime / 2;
        morale = new VillageStatistic(moraleStartingValue, moraleDecreaseRate);
        currentMorale = morale.currentValue;

        InvokeRepeating("DecreaseMorale", moraleIntervalTime, moraleIntervalTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            morale.UpdateDecreaseRateBy(4.0f);
            moraleDecreaseRate = morale.decreaseRate;
        }
    }

    public void DecreaseMorale()
    {
        morale.DecreaseStatistic();
        currentMorale = morale.currentValue;
    }
}
