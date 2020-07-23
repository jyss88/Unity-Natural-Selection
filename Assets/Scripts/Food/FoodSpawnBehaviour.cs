using UnityEngine;
using UnityEngine.UI;

public class FoodSpawnBehaviour : MonoBehaviour, IFoodSpawn
{
    [SerializeField] private FoodSpawnSettings settings;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Text sliderText;

    private float spawnRate;
    private float nextSpawn = 0;
    private Vector2 spawnPlace;
    public int NumSpawn { get; private set; }

    private void Awake() {
        spawnRate = settings.SpawnRate;
        NumSpawn = settings.NumSpawn;
        sliderText.text = NumSpawn.ToString();
    }

    public void ChangeNumSpawn(float numSpawn) {
        NumSpawn = (int) numSpawn;
        sliderText.text = NumSpawn.ToString();
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
