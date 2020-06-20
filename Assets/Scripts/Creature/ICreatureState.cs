using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CState
{
    wander,
    hunt
}
public interface ICreatureState
{    
    CState State { get; set; }
}
