using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StatsManager;

public class AvgStatsTextBehaviour : MonoBehaviour {
    [SerializeField] private StatType statType;
    
    private InputField inputField;
    private Text statText;

    private void OnValidate() {
        statText = GetComponent<Text>();
        inputField = GetComponentInChildren<InputField>();
        statText.text = "Avg " + Stat2Str(statType);
    }

    private void Awake() {
        statText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        inputField.text = GetAvg(StatsManager.Instance.CreatureValues).ToString("F2");
    }

    float GetAvg(Dictionary<ICreature, Dictionary<StatType, float>> creatureList) {
        float total = 0;

        foreach (var creature in creatureList) {
            total += creature.Value[statType];
        }

        return total / creatureList.Count;
    }
}
