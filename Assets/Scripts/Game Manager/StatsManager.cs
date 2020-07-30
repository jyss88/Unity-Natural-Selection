using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats Manager")]
public class StatsManager : SingletonScriptableObject<StatsManager> {
    public enum StatType {
        StartingEnergy,
        Size,
        Velocity,
        SenseRadius,
    }
    public List<Dictionary<StatType, float>> CreatureValues { get; } = new List<Dictionary<StatType, float>>();

    public void AddValue(Dictionary<StatType, float> valueDict) {
        CreatureValues.Add(valueDict);
    }

    public void RemoveValue(Dictionary<StatType, float> valueDict) {
        CreatureValues.Remove(valueDict);
    }
}
