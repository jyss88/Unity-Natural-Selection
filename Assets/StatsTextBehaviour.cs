using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsTextBehaviour : MonoBehaviour
{
    [SerializeField] private CreatureStats.StatType statType;

    Text statText;

    private void Awake() {
        statText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string str = "Avg " + statType.ToString() + ": " + GetAvg(StatsManager.Instance.CreatureValues).ToString("F2");

        statText.text = str;
    }

    float GetAvg(List<Dictionary<CreatureStats.StatType, float>> creatureList) {
        float total = 0;

        foreach (var creature in creatureList) {
            total += creature[statType];
        }

        return total / creatureList.Count;
    }
}
