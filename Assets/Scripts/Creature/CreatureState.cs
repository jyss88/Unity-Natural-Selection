using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureState : ICreatureState
{
    public CState State { get; set; }

    public CreatureState() {
        State = CState.wander;
    }
}
