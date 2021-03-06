﻿/// <summary>
/// Interface for creatures
/// </summary>
public interface ICreature {
    float Energy { get; }
    float StartingEnergy { get; }
    float Velocity { get; }
    float SenseRadius { get; }
    float Size { get; }
    void Mutate(ICreature parent);
}