using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreatureMetabolism : ICreatureAbility
{
    float Energy { get; }
    float StartingEnergy { get; }
    void AddEnergy(float energy);
    void DecreaseEnergy(float energy);
    bool IsEmpty();
}
