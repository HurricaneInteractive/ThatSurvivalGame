using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

struct JSONData {
    public List<string> names;
}

public class VillagerStatistics : MonoBehaviour {
    public new string name = "404";
    private TimeManager timeManager;

    VillageStatistic hunger;
    public float hungerValue = 5.0f;
    public float hungerDecreaseRate = 1.0f;

    VillageStatistic thirst;
    public float thirstValue = 3.0f;
    public float thirstDecreaseRate = 1.0f;

    private int scavengingAbilityMin = 0;
    private int scavengingAbilityMax = 10;
    public int scavengingAbility = 0;

    private void Start() {
        timeManager = new TimeManagerScript().script;
        float dayLength = timeManager.GetDayLength();

        hunger = new VillageStatistic(hungerValue, hungerDecreaseRate);
        thirst = new VillageStatistic(thirstValue, thirstDecreaseRate);

        InvokeRepeating("DecreaseHunger", dayLength, dayLength);
        InvokeRepeating("DecreaseThirst", dayLength, dayLength);

        scavengingAbility = (int)Mathf.Round(Random.Range(scavengingAbilityMin, scavengingAbilityMax));
        List<string> names = GetNameList();

        if (names.Count > 0) {
            name = names[(int)Mathf.Round(Random.Range(0, names.Count))];
        }
    }

    public List<string> GetNameList() {
        string filePath = Path.Combine(Application.streamingAssetsPath, "names.json");
        if (File.Exists(filePath)) {
            string dataAsJson = File.ReadAllText(filePath);
            JSONData data = JsonUtility.FromJson<JSONData>(dataAsJson);
            return data.names;
        }

        return new List<string>();
    }

    public void DecreaseHunger() {
        hunger.DecreaseStatistic();
        hungerValue = hunger.currentValue;
    }

    public void DecreaseThirst() {
        thirst.DecreaseStatistic();
        thirstValue = thirst.currentValue;
    }
}
