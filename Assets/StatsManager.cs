using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats Manager")]
public class StatsManager : SingletonScriptableObject<StatsManager>
{
    public List<Dictionary<CreatureStats.StatType, float>> CreatureValues { get; } = new List<Dictionary<CreatureStats.StatType, float>>();

    public void AddValue(Dictionary<CreatureStats.StatType, float> valueDict) {
        CreatureValues.Add(valueDict);
    }

    public void RemoveValue(Dictionary<CreatureStats.StatType, float> valueDict) {
        CreatureValues.Remove(valueDict);
    }
}
