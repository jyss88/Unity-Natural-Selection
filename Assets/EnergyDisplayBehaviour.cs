using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplayBehaviour : MonoBehaviour, Observer {
    private Text text;
    private InputField inputField;
    private CreatureInfoPanelBehaviour panel;
    private ICreature creature;

    private void OnValidate() {
        text = GetComponent<Text>();

        text.text = "Energy:";
    }

    private void Awake() {
        text = GetComponent<Text>();
        inputField = GetComponentInChildren<InputField>();
        panel = GetComponentInParent<CreatureInfoPanelBehaviour>();
    }

    public void OnNotify() {
        creature = panel.Creature;

        if(creature != null) {
            inputField.text = creature.Energy.ToString("F2");
        }
    }
}
