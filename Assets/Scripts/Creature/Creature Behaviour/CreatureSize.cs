using UnityEngine;

/// <summary>
/// Class representing creature attribute of size
/// </summary>
public class CreatureSize : ICreatureSize {
    private AbilitySettings settings;
    private float size;
    private ICreatureMetabolism metabolism;
    private Transform transform;

    /// <summary>
    /// Size of creature
    /// </summary>
    public float Size { get; set; }

    /// <summary>
    /// Constructor for creature size
    /// </summary>
    /// <param name="settings">Ability settings</param>
    /// <param name="size">Value of size</param>
    /// <param name="metabolism">Creature metabolism</param>
    /// <param name="transform">Creature transform</param>
    public CreatureSize(AbilitySettings settings, float size, ICreatureMetabolism metabolism, Transform transform) {
        this.settings = settings;
        Size = size;
        this.metabolism = metabolism;
        this.transform = transform;

        this.transform.localScale = new Vector3(Size, Size, 1);
    }

    /// <summary>
    /// Ability time cycle
    /// </summary>
    public void Tick() {
        metabolism.DecreaseEnergy(settings.Multiplier * Mathf.Pow(Size, settings.Exponent));
    }
}
