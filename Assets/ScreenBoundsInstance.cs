using UnityEngine;

public class ScreenBoundsInstance : MonoBehaviour
{
    public ScreenBounds bounds;

    private void OnValidate() {
        bounds.UpdateBounds();
    }

    private void Awake()
    {
        bounds.UpdateBounds();
    }
}
