using UnityEngine;

/// <summary>
/// Monobehaviour for creature
/// </summary>
public class CreatureBehaviour : MonoBehaviour, ICreature, IEater {
    [SerializeField] private CreatureSettings settings;
    [SerializeField] private AbilitySettings velocitySettings;
    [SerializeField] private AbilitySettings senseSettings;
    [SerializeField] private AbilitySettings sizeSettings;

    private ICreatureState state;
    private ICreatureMetabolism metabolism;
    private ICreatureMovement movement;
    private ICreatureSense sense;
    private ICreatureSize size;
    private ICreatureFactory creatureFactory;

    public float Energy { get { return metabolism.Energy; } }
    public float StartingEnergy { get { return metabolism.StartingEnergy; } }
    public float Velocity { get { return movement.Velocity; } }
    public float SenseRadius { get { return sense.Radius; } }
    public float Size { get { return size.Size; } }
    public int Generation { get; private set; } = 1;
    public Collider2D Target { get { return sense.Target; } }

    void Awake() {
        state = new CreatureState();
        metabolism = new CreatureMetabolism(gameObject, settings.StartingEnergy);

        size = new CreatureSize(sizeSettings, settings.Size, metabolism, transform);
        sense = new CreatureSense(senseSettings, settings.SenseRadius, state, metabolism, transform);
        movement = new CreatureMovement(velocitySettings, settings.Velocity, state, metabolism, sense, transform);
        creatureFactory = new CreatureFactory(gameObject, this, metabolism, transform, settings.Size);
    }

    // Update is called once per frame
    void FixedUpdate() {
        movement.Tick();
        metabolism.Tick();
        sense.Tick();
        size.Tick();
        creatureFactory.Tick();
    }

    /// <summary>
    /// Adds energy to creature
    /// </summary>
    /// <param name="energy"></param>
    public void Eat(float energy) {
        metabolism.AddEnergy(energy);
    }

    /// <summary>
    /// Mutates attribute value
    /// Returns attribute +- delta mutate
    /// </summary>
    /// <param name="attr">value of attribute</param>
    /// <returns>Mutated attribute value</returns>
    private float MutateAttribute(float attr) {
        return Mathf.Abs(attr + Random.Range(-settings.DeltaMutate, settings.DeltaMutate));
    }

    /// <summary>
    /// Mutates creature attributes, based on parent creature attributes
    /// </summary>
    /// <param name="parent">parent creature</param>
    public void Mutate(ICreature parent) {
        float newStartingEnergy = MutateAttribute(parent.StartingEnergy);
        float newSize = Mathf.Clamp(MutateAttribute(parent.Size), 0.1f, 1000f);
        float newVelocity = MutateAttribute(parent.Velocity);
        float newSenseRadius = MutateAttribute(parent.SenseRadius);

        metabolism = new CreatureMetabolism(gameObject, newStartingEnergy);
        size = new CreatureSize(sizeSettings, newSize, metabolism, transform);
        sense = new CreatureSense(senseSettings, newSenseRadius, state, metabolism, transform);
        movement = new CreatureMovement(velocitySettings, newVelocity, state, metabolism, sense, transform);
        creatureFactory = new CreatureFactory(gameObject, this, metabolism, transform, newSize);

        Generation = parent.Generation + 1;
    }
}
