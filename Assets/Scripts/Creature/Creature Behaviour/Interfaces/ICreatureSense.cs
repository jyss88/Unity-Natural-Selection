using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreatureSense : ICreatureAbility
{
    float Radius { get; }
    Collider2D Target { get; }
}
