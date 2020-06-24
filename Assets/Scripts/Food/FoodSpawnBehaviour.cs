using UnityEngine;

public class FoodSpawnBehaviour : MonoBehaviour, IFoodSpawn
{
    public FoodSpawnSettings settings;
    public GameObject foodPrefab;

    private float spawnRate;
    private float nextSpawn = 0;
    private Vector2 spawnPlace;
    public int NumSpawn { get; private set; }

    private void Awake() {
        spawnRate = settings.SpawnRate;
        NumSpawn = settings.NumSpawn;
    }

    public void ChangeNumSpawn(float numSpawn) {
        NumSpawn = (int) numSpawn;
    }

    public void Tick() {
        if (Time.time > nextSpawn) {
            nextSpawn = Time.time + spawnRate;

            for (int i = 0; i < NumSpawn; i++) {
                spawnPlace = new Vector2(Random.Range(ScreenBounds.Instance.MinX, ScreenBounds.Instance.MaxX), Random.Range(ScreenBounds.Instance.MinY, ScreenBounds.Instance.MaxY));

                GameObject foodObj = Instantiate(foodPrefab, spawnPlace, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Tick();
    }
}
