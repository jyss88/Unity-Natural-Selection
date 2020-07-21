using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR;

[CustomEditor(typeof(ScreenBoundsInstance))]
public class ScreenBoundsEditor : Editor
{
    private void OnSceneGUI()
    {

        Vector3[] corners = { new Vector2(ScreenBounds.Instance.MaxX, ScreenBounds.Instance.MaxY), new Vector2(ScreenBounds.Instance.MaxX, ScreenBounds.Instance.MinY), new Vector2(ScreenBounds.Instance.MinX, ScreenBounds.Instance.MinY), new Vector2(ScreenBounds.Instance.MinX, ScreenBounds.Instance.MaxY), new Vector2(ScreenBounds.Instance.MaxX, ScreenBounds.Instance.MaxY) };

        Handles.color = Color.cyan;
        Handles.DrawPolyLine(corners);

    }
}
