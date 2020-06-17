using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Creature/Creature Settings")]
public class CreatureSettings : ScriptableObject
{
#pragma warning disable 0649
    [SerializeField] private float velocity;
    [SerializeField] private float startingEnergy;
#pragma warning restore 0649

    public float Velocity { get { return velocity; } } 
    public float StartingEnergy { get { return startingEnergy; } }
}
