using UnityEngine;

public class CreatureBehaviour : MonoBehaviour, IEater
{
#pragma warning disable 0649
    [SerializeField] private CreatureSettings settings;
    [SerializeField] private AbilitySettings velocitySettings;
    [SerializeField] private AbilitySettings senseSettings;
    [SerializeField] private AbilitySettings sizeSettings;
#pragma warning restore 0649

    private bool isSet = false;

    private ICreatureState state;
    private ICreatureMetabolism metabolism;
    private ICreatureMovement movement;
    private ICreatureSense sense;
    private ICreatureSize size;
    private ICreatureFactory creatureFactory;

    public float Energy { get { return metabolism.Energy;} }
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
        creatureFactory = new CreatureFactory(gameObject, metabolism, transform, settings.Size, settings.Velocity, settings.SenseRadius);
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

    public void SetAttributes(float startingEnergy, float size, float velocity, float senseRadius) {
        if (!isSet) {
            state = new CreatureState();
            metabolism = new CreatureMetabolism(gameObject, startingEnergy);

            this.size = new CreatureSize(sizeSettings, size, metabolism, transform);
            sense = new CreatureSense(senseSettings, senseRadius, state, metabolism, transform);
            movement = new CreatureMovement(velocitySettings, velocity, state, metabolism, sense, transform);
            creatureFactory = new CreatureFactory(gameObject, metabolism, transform, size, velocity, senseRadius);

            isSet = true;
        } else {
            Debug.Log("attributes have already been set.");
        }
    }
}
