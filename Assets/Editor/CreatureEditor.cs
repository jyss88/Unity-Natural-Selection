using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

[CustomEditor (typeof(CreatureBehaviour))]
public class CreatureEditor : Editor
{
    private CreatureBehaviour creature;

    private void OnEnable() {
        creature = (CreatureBehaviour)target;
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        if (Application.isPlaying)
        {
            EditorGUILayout.LabelField("Energy");
            EditorGUILayout.FloatField(creature.Energy);

            EditorGUILayout.LabelField("Size");
            EditorGUILayout.FloatField(creature.Size);

            EditorGUILayout.LabelField("Velocity");
            EditorGUILayout.FloatField(creature.Velocity);

            EditorGUILayout.LabelField("Sense Radius");
            EditorGUILayout.FloatField(creature.SenseRadius);
        }
    }

    private void OnSceneGUI() {
        if (Application.isPlaying)
        {
            Handles.color = Color.red;
            Handles.DrawWireArc(creature.transform.position, Vector3.forward, Vector3.right, 360, creature.SenseRadius);

            if (creature.Target)
            {
                Handles.color = Color.blue;
                Handles.DrawWireArc(creature.Target.transform.position, Vector3.forward, Vector3.right, 360, 0.75f);
            }
        }
    }
}
