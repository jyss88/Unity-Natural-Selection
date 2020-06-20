﻿using System;
using UnityEngine;

public class CreatureBehaviour : MonoBehaviour, IEater
{
#pragma warning disable 0649
    [SerializeField] private CreatureSettings settings;
    [SerializeField] private AbilitySettings velocitySettings;
    [SerializeField] private AbilitySettings senseSettings;
#pragma warning restore 0649
    private ICreatureState state;
    private ICreatureMetabolism metabolism;
    private ICreatureMovement movement;
    private ICreatureSense sense;

    public float Energy { get { return metabolism.Energy;} }
    public float Velocity { get { return movement.Velocity; } }
    public float SenseRadius { get { return sense.Radius; } }

    private void OnValidate() {
        state = new CreatureState();
        metabolism = new CreatureMetabolism(gameObject, settings.StartingEnergy);
        movement = new CreatureMovement(velocitySettings, settings.Velocity, metabolism, transform);
        sense = new CreatureSense(senseSettings, settings.SenseRadius, state, metabolism, transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.Tick();
        metabolism.Tick();
        sense.Tick();
    }

    public void Eat(float energy) {
        metabolism.AddEnergy(energy);
    }
}
