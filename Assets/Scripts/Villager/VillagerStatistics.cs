using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

struct JSONData {
    public List<string> names;
}

public class VillagerStatistics : MonoBehaviour {
    public new string name;

    public int hunger = 0;
    public int thirst = 0;
    public float morale = 100.0f;

    private int scavengingAbilityMin = 0;
    private int scavengingAbilityMax = 10;
    public int scavengingAbility = 0;

    private void Start() {
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
        else {
            Debug.Log("File not found");
        }

        return new List<string>();
    }
}
