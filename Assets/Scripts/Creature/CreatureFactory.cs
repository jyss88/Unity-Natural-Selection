using UnityEngine;

public class CreatureFactory : ICreatureFactory
{
    private ICreatureMetabolism metabolism;
    private GameObject prefab;
    private Transform transform;
    private float size, velocity, sightRadius;
    private float deltaMutate;

    public CreatureFactory(GameObject prefab, ICreatureMetabolism metabolism, Transform transform, float size, float velocity, float sightRadius) {
        this.prefab = prefab;

        this.transform = transform;
        this.metabolism = metabolism;
        this.size = size;
        this.velocity = velocity;
        this.sightRadius = sightRadius;
    }

    public GameObject Reproduce() {
        Vector3 offsetVector = new Vector3(transform.localScale.x, transform.localScale.y);
        return Object.Instantiate(prefab, transform.position + offsetVector, Quaternion.identity);
    }

    public void Tick() {
        if (metabolism.Energy > (metabolism.StartingEnergy + size * 10)) {
            Reproduce();

            metabolism.DecreaseEnergy(metabolism.StartingEnergy);
        }
    }
}
