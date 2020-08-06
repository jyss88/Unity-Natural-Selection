using UnityEngine;
using UnityEngine.UI;
using static StatsManager;

public class CreatureStatDisplayBehaviour : MonoBehaviour, Observer {
    [SerializeField] private StatType statType;

    private Text text;
    private InputField inputField;
    private CreatureInfoPanelBehaviour panel;
    private ICreature creature;

    private void OnValidate() {
        text = GetComponent<Text>();
        text.text = Stat2Str(statType) + ":";
    }

    private void Awake() {
        text = GetComponent<Text>();
        inputField = GetComponentInChildren<InputField>();
        panel = GetComponentInParent<CreatureInfoPanelBehaviour>();

        inputField.enabled = true;
    }

    public void OnNotify() {
        Debug.Log("Creature stat display updated");
        creature = panel.Creature;

        if (creature != null) {
            inputField.text = StatsManager.Instance.CreatureValues[creature][statType].ToString("F2");
        }
    }
}
