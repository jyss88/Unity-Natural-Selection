using UnityEngine;

public class CreatureBehaviour : MonoBehaviour, IEater
{
#pragma warning disable 0649
    [SerializeField] private CreatureSettings settings;
    [SerializeField] private AbilitySettings velocitySettings;
#pragma warning restore 0649
    private ICreatureMetabolism metabolism;
    private ICreatureMovement movement;

    public float Energy { 
        get { 
            try {
                return metabolism.Energy;
            } catch {
                return 0.0f;
            }
        } 
    }

    private void Awake() {
        metabolism = new CreatureMetabolism(gameObject, settings.StartingEnergy);
        movement = new CreatureMovement(settings.Velocity, transform, velocitySettings, metabolism);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.Tick();
        metabolism.Tick();
    }

    public void Eat(float energy) {
        metabolism.AddEnergy(energy);
    }
}
