using UnityEngine;

[CreateAssetMenu(menuName = "Creature/Creature Settings")]
public class CreatureSettings : ScriptableObject
{
#pragma warning disable 0649
    [SerializeField] private float velocity = 1;
    [SerializeField] private float startingEnergy = 20;
    [SerializeField] private float senseRadius = 2;
    [SerializeField] private float size = 1;
    [SerializeField] private float deltaMutate = 0.1f;
#pragma warning restore 0649

    public float Velocity { get { return velocity; } } 
    public float StartingEnergy { get { return startingEnergy; } }
    public float SenseRadius { get { return senseRadius; } }
    public float Size { get { return size; } }
    public float DeltaMutate { get { return deltaMutate; } }
}
