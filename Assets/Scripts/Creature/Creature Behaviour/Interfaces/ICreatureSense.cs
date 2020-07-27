using UnityEngine;

public interface ICreatureSense : ICreatureAbility {
    float Radius { get; }
    Collider2D Target { get; }
}
