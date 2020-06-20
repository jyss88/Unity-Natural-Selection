using UnityEngine;

public class CreatureSense : ICreatureSense
{
    private AbilitySettings settings;
    private ICreatureState state;
    private Transform transform;
    private ICreatureMetabolism metabolism;
    public float Radius { get; private set; }
    public Collider2D Target { get; private set; }

    public CreatureSense(AbilitySettings settings, float radius, ICreatureState state, ICreatureMetabolism metabolism, Transform transform) {
        this.settings = settings;
        Radius = radius;
        this.state = state;
        this.transform = transform;
        this.metabolism = metabolism;
    }
    public void Tick() {
        FindVisibleFood();
        metabolism.DecreaseEnergy(settings.Multiplier * Mathf.Pow(Radius, settings.Exponent * Time.deltaTime));
    }

    private void FindVisibleFood() {
        Target = Physics2D.OverlapCircle(transform.position, Radius);

        if (Target) {
            Debug.Log("Target found");
            state.State = CState.hunt;
        } else {
            state.State = CState.wander;
        }
    }
}
