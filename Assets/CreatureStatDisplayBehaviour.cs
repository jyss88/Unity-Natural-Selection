using UnityEngine;
using UnityEngine.UI;
using static StatsManager;

public class CreatureStatDisplayBehaviour : MonoBehaviour {
    [SerializeField] private StatType statType;

    private Text text;
    private InputField inputField;
    private CreatureInfoPanelBehaviour panel;

    private void OnValidate() {
        text = GetComponent<Text>();
        text.text = statType.ToString();
    }

    private void Awake() {
        text = GetComponent<Text>();
        inputField = GetComponentInChildren<InputField>();
        panel = GetComponentInParent<CreatureInfoPanelBehaviour>();

        //inputField.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
