using UnityEngine;

public class FoodBehaviour : MonoBehaviour, IEdible
{
#pragma warning disable 0649
    [SerializeField] private FoodSettings settings;
#pragma warning restore 0649
    public float Nutrition { get; private set; }

    public void FeedTo(IEater creature) {
        creature.Eat(Nutrition);
        Destroy(gameObject);
    }

    public void Awake() {
        Nutrition = settings.Nutrition;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Creature")){
            Debug.Log("Collided with creature");
            FeedTo(collision.gameObject.GetComponent<IEater>());
        }
    }
}
