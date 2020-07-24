using UnityEngine;

[CreateAssetMenu(menuName = "ScreenBounds")]
public class ScreenBounds : SingletonScriptableObject<ScreenBounds> {
    [SerializeField] private float topOffset = 0;
    [SerializeField] private float bottomOffset = 0;
    [SerializeField] private float rightOffset = 0;
    [SerializeField] private float leftOffset = 0;

    public float MaxX { get; private set; }

    public float MaxY { get; private set; }

    public float MinX { get; private set; }

    public float MinY { get; private set; }

    public float Width { get; private set; }

    public float Height { get; private set; }

    private void Awake() {
        //UpdateBounds();
    }

    public void UpdateBounds() {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Convert to X and Y coordinates
        MaxX = screenBounds.x - rightOffset;
        MinX = -screenBounds.x + leftOffset;
        MaxY = screenBounds.y - topOffset;
        MinY = -screenBounds.y + bottomOffset;

        Width = MaxX - MinX;
        Height = MaxY - MinY;
    }
}
