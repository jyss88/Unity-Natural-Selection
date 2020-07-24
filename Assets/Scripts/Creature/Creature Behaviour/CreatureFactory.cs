using UnityEngine;

/// <summary>
/// Class handling creature reproduction
/// </summary>
public class CreatureFactory : ICreatureFactory {
    private ICreatureMetabolism metabolism;
    private ICreature parent;
    private GameObject prefab;
    private Transform transform;
    private float size;

    /// <summary>
    /// Constructor for CreatureFactory
    /// </summary>
    /// <param name="prefab">Creature prefab</param>
    /// <param name="parent">Parent creature</param>
    /// <param name="metabolism">Creature metabolism</param>
    /// <param name="transform">Creature transform</param>
    /// <param name="size">Creature size</param>
    public CreatureFactory(GameObject prefab, ICreature parent, ICreatureMetabolism metabolism, Transform transform, float size) {
        this.prefab = prefab;
        this.parent = parent;
        this.transform = transform;
        this.metabolism = metabolism;
        this.size = size;
    }

    /// <summary>
    /// Creature reproduces and mutates
    /// </summary>
    /// <returns>Child creature</returns>
    public GameObject Reproduce() {
        Vector3 offsetVector = new Vector3(transform.localScale.x, transform.localScale.y);
        GameObject newCreature = Object.Instantiate(prefab, transform.position + offsetVector, Quaternion.identity);
        newCreature.GetComponent<ICreature>().Mutate(parent);

        return newCreature;
    }

    /// <summary>
    /// Creature cycle
    /// </summary>
    public void Tick() {
        if (metabolism.Energy > (metabolism.StartingEnergy + size * 10)) {
            Reproduce();

            metabolism.DecreaseEnergy(metabolism.StartingEnergy);
        }
    }
}
