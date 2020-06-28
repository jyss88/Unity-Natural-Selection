using UnityEngine;

public class CreatureBehaviour : MonoBehaviour, ICreature, IEater
{
#pragma warning disable 0649
    [SerializeField] private CreatureSettings settings;
    [SerializeField] private AbilitySettings velocitySettings;
    [SerializeField] private AbilitySettings senseSettings;
    [SerializeField] private AbilitySettings sizeSettings;
#pragma warning restore 0649

    private ICreatureState state;
    private ICreatureMetabolism metabolism;
    private ICreatureMovement movement;
    private ICreatureSense sense;
    private ICreatureSize size;
    private ICreatureFactory creatureFactory;

    public float Energy { get { return metabolism.Energy;} }
    public float StartingEnergy { get { return metabolism.StartingEnergy; } }
    public float Velocity { get { return movement.Velocity; } }
    public float SenseRadius { get { return sense.Radius; } }
    public float Size { get { return size.Size; } }
    public Collider2D Target { get { return sense.Target; } }

    private void Awake() {
        state = new CreatureState();
        metabolism = new CreatureMetabolism(gameObject, settings.StartingEnergy);

        size = new CreatureSize(sizeSettings, settings.Size, metabolism, transform);
        sense = new CreatureSense(senseSettings, settings.SenseRadius, state, metabolism, transform);
        movement = new CreatureMovement(velocitySettings, settings.Velocity, state, metabolism, sense, transform);
        creatureFactory = new CreatureFactory(gameObject, this, metabolism, transform, settings.Size);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.Tick();
        metabolism.Tick();
        sense.Tick();
        size.Tick();
        creatureFactory.Tick();
    }

    public void Eat(float energy) {
        metabolism.AddEnergy(energy);
    }

    private float MutateAttribute(float attr) {
        return Mathf.Abs(attr + Random.Range(-settings.DeltaMutate, settings.DeltaMutate));
    }

    public void Mutate(ICreature source) {
        float newStartingEnergy = MutateAttribute(source.StartingEnergy);
        float newSize = Mathf.Clamp(MutateAttribute(source.Size), 0.1f, 1000f);
        float newVelocity = MutateAttribute(source.Velocity);
        float newSenseRadius = MutateAttribute(source.SenseRadius);

        metabolism = new CreatureMetabolism(gameObject, newStartingEnergy);
        size = new CreatureSize(sizeSettings, newSize, metabolism, transform);
        movement = new CreatureMovement(velocitySettings, MutateAttribute(source.Velocity), state, metabolism, sense, transform);
        creatureFactory = new CreatureFactory(gameObject, this, metabolism, transform, newSize);
    }
}
