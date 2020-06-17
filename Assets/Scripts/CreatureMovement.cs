using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMovement : ICreatureMovement
{
    private float velocity;
    private Transform transform;
    private AbilitySettings settings;
    private float minX, maxX, minY, maxY;
    private Vector2 moveSpot;
    private float timeSinceChanged = 0;

    public CreatureMovement(float velocity, Transform transform, AbilitySettings settings) {
        this.velocity = velocity;
        this.transform = transform;
        this.settings = settings;

        moveSpot = CreateMoveSpot();

        minX = ScreenBounds.Instance.MinX;
        maxX = ScreenBounds.Instance.MaxX;
    }

    public void Tick() {
        Move();
    }

    /// <summary>
    /// Creautes a random movepoint
    /// </summary>
    /// <returns>Move point</returns>
    private Vector2 CreateMoveSpot() {
        return new Vector2(Random.Range(ScreenBounds.Instance.MinX, ScreenBounds.Instance.MaxX), Random.Range(ScreenBounds.Instance.MinY, ScreenBounds.Instance.MaxY));
    }

    private void Move() {
        MoveRandomly();
    }

    private void MoveRandomly() {
        float minDist = 0.2f;

        // Move towards move spot
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, velocity * Time.deltaTime);
        timeSinceChanged += Time.deltaTime;

        // If reached move spot, create new movespot
        if (Vector2.Distance(transform.position, moveSpot) < minDist || timeSinceChanged > 10) {
            moveSpot = CreateMoveSpot();
            timeSinceChanged = 0;
        }
    }
}
