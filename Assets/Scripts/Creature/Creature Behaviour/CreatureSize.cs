using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSize : ICreatureSize
{
    private AbilitySettings settings;
    private float size;
    private ICreatureMetabolism metabolism;
    private Transform transform;

    public float Size { get; set; }

    public CreatureSize(AbilitySettings settings, float size, ICreatureMetabolism metabolism, Transform transform) {
        this.settings = settings;
        Size = size;
        this.metabolism = metabolism;
        this.transform = transform;

        this.transform.localScale = new Vector3(Size, Size, 1);
    }

    public void Tick() {
        metabolism.DecreaseEnergy(settings.Multiplier * Mathf.Pow(Size, settings.Exponent));
    }
}
