using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    private TimeManager timeManager;
    private Camera cam;
    private VillagerStatistics villagerStatisticsScript;
    private GameObject[] villagers;

    public VillageStatistic morale;
    public float moraleStartingValue = 100.0f;
    public float moraleDecreaseRate = 1.0f;
    public float currentMorale;
    public float moraleIntervalTime;
    public GameObject villagerStatistics;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = new TimeManagerScript().script;
        cam = Camera.main;
        villagerStatisticsScript = (VillagerStatistics)villagerStatistics.GetComponent(typeof(VillagerStatistics));
        villagers = GameObject.FindGameObjectsWithTag(Enum.GetName(typeof(Tags), 2));

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

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject clickedGameObject = hit.transform.gameObject;
                if (clickedGameObject.tag == Enum.GetName(typeof(Tags), 2)) {
                    resetVillagerShaders();
                    villagerStatisticsScript.OpenStatistics(clickedGameObject);
                }
            }
        }
    }

    public void DecreaseMorale()
    {
        morale.DecreaseStatistic();
        currentMorale = morale.currentValue;
    }

    public void resetVillagerShaders() {
        foreach(GameObject obj in villagers) {
            Villager villagerScript = (Villager)obj.GetComponent(typeof(Villager));
            villagerScript.resetToDefaultShader();
        }
    }
}
