using UnityEngine;

/// <summary>
/// Class representing creature movement ability
/// </summary>
public class CreatureMovement : ICreatureMovement {
    private Transform transform;
    private ICreatureState state;
    private ICreatureMetabolism metabolism;
    private ICreatureSense sense;
    private AbilitySettings settings;
    private Vector2 moveSpot;
    private float timeSinceChanged = 0;

    public float Velocity { get; private set; }

    /// <summary>
    /// Constructor for creature velocity
    /// </summary>
    /// <param name="settings">Ability settings</param>
    /// <param name="velocity">Velocity value</param>
    /// <param name="state">Creature state</param>
    /// <param name="metabolism">Creature metabolism</param>
    /// <param name="sense">Creature sense</param>
    /// <param name="transform">Creature transform</param>
    public CreatureMovement(AbilitySettings settings, float velocity, ICreatureState state, ICreatureMetabolism metabolism, ICreatureSense sense, Transform transform) {
        Velocity = velocity;
        this.state = state;
        this.transform = transform;
        this.settings = settings;
        this.metabolism = metabolism;
        this.sense = sense;

        moveSpot = CreateMoveSpot();
    }

    /// <summary>
    /// Update cycle
    /// </summary>
    public void Tick() {
        Move();
        metabolism.DecreaseEnergy(settings.Multiplier * Mathf.Pow(Velocity, settings.Exponent * Time.deltaTime));
    }

    /// <summary>
    /// Creautes a random movepoint
    /// </summary>
    /// <returns>Move point</returns>
    private Vector2 CreateMoveSpot() {
        return new Vector2(Random.Range(ScreenBounds.Instance.MinX, ScreenBounds.Instance.MaxX), Random.Range(ScreenBounds.Instance.MinY, ScreenBounds.Instance.MaxY));
    }

    /// <summary>
    /// Moves creature
    /// Either randomly, or towards target
    /// </summary>
    private void Move() {
        switch (state.State) {
            case CState.wander:
                MoveRandomly();
                break;
            case CState.hunt:
                MoveToTarget(sense.Target);
                break;
            default:
                MoveRandomly();
                break;
        }
    }

    /// <summary>
    /// Randomly moves creature
    /// </summary>
    private void MoveRandomly() {
        float minDist = 0.2f;

        // Move towards move spot
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, Velocity * Time.deltaTime);
        timeSinceChanged += Time.deltaTime;

        // If reached move spot, create new movespot
        if (Vector2.Distance(transform.position, moveSpot) < minDist || timeSinceChanged > 10) {
            moveSpot = CreateMoveSpot();
            timeSinceChanged = 0;
        }
    }

    /// <summary>
    /// Moves creature towards target
    /// </summary>
    /// <param name="target">Target collider</param>
    private void MoveToTarget(Collider2D target) {
        if (target) {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Velocity * Time.deltaTime);
        } else {
            state.State = CState.wander;
            MoveRandomly();
        }
    }
}