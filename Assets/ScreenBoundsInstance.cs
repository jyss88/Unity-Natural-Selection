using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundsInstance : MonoBehaviour
{
    public ScreenBounds bounds;

    private void OnValidate() {
        bounds.UpdateBounds();
    }
}
