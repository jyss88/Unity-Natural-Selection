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
    public Dictionary<ICreature, Dictionary<StatType, float>> CreatureValues { get; } = new Dictionary<ICreature, Dictionary<StatType, float>>();
}
