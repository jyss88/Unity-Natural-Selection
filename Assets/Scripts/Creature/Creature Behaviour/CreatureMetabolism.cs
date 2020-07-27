using UnityEngine;

/// <summary>
/// Class representing metabolism of creature
/// </summary>
public class CreatureMetabolism : ICreatureMetabolism {
    private GameObject creature;
    public float Energy { get; private set; }

    public float StartingEnergy { get; private set; }

    /// <summary>
    /// Constructor for metabolism
    /// </summary>
    /// <param name="creature">Creature game object</param>
    /// <param name="startingEnergy">Starting energy of creature</param>
    public CreatureMetabolism(GameObject creature, float startingEnergy) {
        this.creature = creature;
        StartingEnergy = startingEnergy;
        Energy = StartingEnergy;
    }

    /// <summary>
    /// Update cycle
    /// </summary>
    public void Tick() {
        if (Energy <= 0) {
            Object.Destroy(creature); // Kills creature if out of energy
        }
    }

    /// <summary>
    /// Adds energy to creature
    /// </summary>
    /// <param name="energy">Energy value</param>
    public void AddEnergy(float energy) {
        Energy += energy;
    }

    /// <summary>
    /// Decreases energy
    /// </summary>
    /// <param name="energy">Energy value</param>
    public void DecreaseEnergy(float energy) {
        Energy -= energy;
    }
}
