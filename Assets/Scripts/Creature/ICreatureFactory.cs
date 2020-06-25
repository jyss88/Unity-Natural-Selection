using UnityEngine;

public interface ICreatureFactory : ICreatureAbility
{
    GameObject Reproduce();
}
