using UnityEngine;

public class CreatureFactory : ICreatureFactory
{
    private ICreatureMetabolism metabolism;
    private ICreature source;
    private GameObject prefab;
    private Transform transform;
    private float size;

    public CreatureFactory(GameObject prefab, ICreature source, ICreatureMetabolism metabolism, Transform transform, float size) {
        this.prefab = prefab;
        this.source = source;
        this.transform = transform;
        this.metabolism = metabolism;
        this.size = size;
    }

    public GameObject Reproduce() {
        Vector3 offsetVector = new Vector3(transform.localScale.x, transform.localScale.y);
        GameObject newCreature = Object.Instantiate(prefab, transform.position + offsetVector, Quaternion.identity);
        newCreature.GetComponent<ICreature>().Mutate(source);

        return newCreature;
    }

    public void Tick() {
        if (metabolism.Energy > (metabolism.StartingEnergy + size * 10)) {
            Reproduce();

            metabolism.DecreaseEnergy(metabolism.StartingEnergy);
        }
    }
}
