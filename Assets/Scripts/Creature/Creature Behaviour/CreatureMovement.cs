using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : ICreatureMovement
{
    public float Velocity { get; private set; }
    private Transform transform;
    private ICreatureState state;
    private ICreatureMetabolism metabolism;
    private ICreatureSense sense;
    private AbilitySettings settings;
    private Vector2 moveSpot;
    private float timeSinceChanged = 0;

    public CreatureMovement(AbilitySettings settings, float velocity, ICreatureState state, ICreatureMetabolism metabolism, ICreatureSense sense, Transform transform) {
        Velocity = velocity;
        this.state = state;
        this.transform = transform;
        this.settings = settings;
        this.metabolism = metabolism;
        this.sense = sense;

        moveSpot = CreateMoveSpot();
    }

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

    private void MoveToTarget(Collider2D target) {
        if (target) {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Velocity * Time.deltaTime);
        } else {
            state.State = CState.wander;
            MoveRandomly();
        }
    }
}