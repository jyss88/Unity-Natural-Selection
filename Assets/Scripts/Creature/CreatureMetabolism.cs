using UnityEngine;

public class CreatureMetabolism : ICreatureMetabolism
{
    public float Energy { get; private set; }

    public float StartingEnergy { get; private set; }

    private GameObject creature;

    public CreatureMetabolism(GameObject creature, float startingEnergy) {
        this.creature = creature;
        StartingEnergy = startingEnergy;
        Energy = StartingEnergy;
    }

    public void Tick() {
        if (Energy <= 0) {
            Object.Destroy(creature);
        }
    }

    public void AddEnergy(float energy) {
        Energy += energy;
    }

    public void DecreaseEnergy(float energy) {
        Energy -= energy;
    }
}
