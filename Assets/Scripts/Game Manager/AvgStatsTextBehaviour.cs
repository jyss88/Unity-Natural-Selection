using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using static StatsManager;

public class AvgStatsTextBehaviour : MonoBehaviour {
    [SerializeField] private StatType statType;

    private Text statText;

    private void OnValidate() {
        statText = GetComponent<Text>();
        statText.text = "Avg " + Stat2Str(statType) + ": 0.00";
    }

    private void Awake() {
        statText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        statText.text = "Avg " + Stat2Str(statType) + ": " + GetAvg(StatsManager.Instance.CreatureValues).ToString("F2");
    }

    float GetAvg(Dictionary<ICreature, Dictionary<StatType, float>> creatureList) {
        float total = 0;

        foreach (var creature in creatureList) {
            total += creature.Value[statType];
        }

        return total / creatureList.Count;
    }
}
