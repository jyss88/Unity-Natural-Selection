using UnityEditor;

[CustomEditor (typeof(CreatureBehaviour))]
public class CreatureEditor : Editor
{
    private CreatureBehaviour creature;

    private void OnEnable() {
        creature = (CreatureBehaviour)target;
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        EditorGUILayout.LabelField("Energy");
        EditorGUILayout.FloatField(creature.Energy);
    }
}
