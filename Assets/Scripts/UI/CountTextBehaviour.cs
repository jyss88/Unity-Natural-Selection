using UnityEngine;
using UnityEngine.UI;

public class CountTextBehaviour : MonoBehaviour {
    private InputField inputField;
    private Text countText;

    private void OnValidate() {
        countText = GetComponent<Text>();
        inputField = GetComponentInChildren<InputField>();
        countText.text = "No Creatures";
    }

    private void Awake() {
        countText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        inputField.text = StatsManager.Instance.CreatureValues.Count.ToString();
    }
}
