using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreature
{
    float Energy { get; }
    float StartingEnergy { get; }
    float Velocity { get; }
    float SenseRadius { get; }
    float Size { get; }
    void Mutate(ICreature source);
}
