using UnityEngine;

[CreateAssetMenu(menuName = "Food/Food Spawner Settings")]
public class FoodSpawnSettings : ScriptableObject
{
    [SerializeField] private int numSpawn = 10;
    [SerializeField] private float spawnRate = 1;

    public int NumSpawn { get { return numSpawn; } }
    public float SpawnRate { get { return spawnRate; } }
}
