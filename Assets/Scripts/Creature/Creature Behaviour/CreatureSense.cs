using UnityEngine;

/// <summary>
/// Class representing creature ability of sense
/// </summary>
public class CreatureSense : ICreatureSense {
    private AbilitySettings settings;
    private ICreatureState state;
    private Transform transform;
    private ICreatureMetabolism metabolism;
    
    public float Radius { get; private set; }
    
    public Collider2D Target { get; private set; }

    /// <summary>
    /// Constructor for creature sense
    /// </summary>
    /// <param name="settings">Ability settings</param>
    /// <param name="radius">Value of sight radius</param>
    /// <param name="state">Creature state</param>
    /// <param name="metabolism">Creature metabolism</param>
    /// <param name="transform">Creature transform</param>
    public CreatureSense(AbilitySettings settings, float radius, ICreatureState state, ICreatureMetabolism metabolism, Transform transform) {
        this.settings = settings;
        Radius = radius;
        this.state = state;
        this.transform = transform;
        this.metabolism = metabolism;
    }

    /// <summary>
    /// Update cycle
    /// </summary>
    public void Tick() {
        FindVisibleFood();
        metabolism.DecreaseEnergy(settings.Multiplier * Mathf.Pow(Radius, settings.Exponent * Time.deltaTime));
    }

    /// <summary>
    /// Finds food within sight radius
    /// Puts nearest target into target
    /// </summary>
    private void FindVisibleFood() {
        if (state.State == CState.wander) {
            Target = Physics2D.OverlapCircle(transform.position, Radius, LayerMask.GetMask("Food"));

            if (Target) {
                state.State = CState.hunt;
            }
        }
    }
}
