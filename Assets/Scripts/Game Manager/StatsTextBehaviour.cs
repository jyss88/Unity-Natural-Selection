using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class StatsTextBehaviour : MonoBehaviour
{
    [SerializeField] private CreatureStats.StatType statType;

    private Text statText;

    private void OnValidate()
    {
        statText = GetComponent<Text>();
        statText.text = "Avg " + SplitString(statType.ToString()) + ": 0.00";
    }

    private void Awake() {
        statText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        statText.text = "Avg " + SplitString(statType.ToString()) + ": " + GetAvg(StatsManager.Instance.CreatureValues).ToString("F2");
    }

    float GetAvg(List<Dictionary<CreatureStats.StatType, float>> creatureList) {
        float total = 0;

        foreach (var creature in creatureList) {
            total += creature[statType];
        }

        return total / creatureList.Count;
    }

    private string SplitString(string str)
    {
        return string.Join(" ", Regex.Split(str, @"(?<!^)(?=[A-Z](?![A-Z]|$))"));
    }
}
