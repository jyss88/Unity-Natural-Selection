using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats Manager")]
public class StatsManager : SingletonScriptableObject<StatsManager> {
    public enum StatType {
        StartingEnergy,
        Size,
        Velocity,
        SenseRadius,
    }
    public Dictionary<ICreature, Dictionary<StatType, float>> CreatureValues { get; } = new Dictionary<ICreature, Dictionary<StatType, float>>();

    public static string Stat2Str(StatType stat) {
        return string.Join(" ", Regex.Split(stat.ToString(), @"(?<!^)(?=[A-Z](?![A-Z]|$))"));
    }
}
