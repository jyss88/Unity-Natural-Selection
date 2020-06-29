using System.Collections.Generic;
using UnityEngine;

public class CreatureStats : MonoBehaviour
{
    public enum StatType
    {
        StartingEnergy,
        Size,
        Velocity,
        SenseRadius,
    }

    private ICreature creature;

    public Dictionary<StatType, float> Values { get; } = new Dictionary<StatType, float>();

    private void Start() {
        creature = GetComponent<ICreature>();
        Values[StatType.StartingEnergy] = creature.StartingEnergy;
        Values[StatType.Size] = creature.Size;
        Values[StatType.Velocity] = creature.Velocity;
        Values[StatType.SenseRadius] = creature.SenseRadius;

        StatsManager.Instance.AddValue(Values);
    }

    private void OnDestroy() {
        StatsManager.Instance.RemoveValue(Values);
    }
}
