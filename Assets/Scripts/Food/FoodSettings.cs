using UnityEngine;

[CreateAssetMenu(menuName = "Food/Food Settings")]
public class FoodSettings : ScriptableObject
{
    [SerializeField] private float nutrition = 10;
    public float Nutrition { get { return nutrition; } }
}
