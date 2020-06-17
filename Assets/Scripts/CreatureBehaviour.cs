using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehaviour : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private CreatureSettings settings;
    [SerializeField] AbilitySettings velocitySettings;
#pragma warning restore 0649
    private ICreatureMetabolism metabolism;
    private ICreatureMovement movement;

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
}
