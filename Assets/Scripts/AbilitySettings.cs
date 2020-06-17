using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Creature/Ability Settings")]
public class AbilitySettings : ScriptableObject
{
#pragma warning disable 0649
    [SerializeField] private float multiplier;
    [SerializeField] private int exponent;
#pragma warning restore 0649
    public float Multiplier { get { return multiplier; } }
    public float Exponent { get { return exponent; } }
}
