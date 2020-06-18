using UnityEngine;

public class FoodBehaviour : MonoBehaviour, IEdible
{
    [SerializeField] private FoodSettings settings;
    public float Nutrition { get; private set; }

    public void FeedTo(CreatureBehaviour creature) {
        creature.Eat(Nutrition);
        Destroy(gameObject);
    }

    public void Awake() {
        Nutrition = settings.Nutrition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Creature")){
            Debug.Log("Collided with creature");
            FeedTo(collision.gameObject.GetComponent<CreatureBehaviour>());
        }
    }
}
