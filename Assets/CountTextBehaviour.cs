using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTextBehaviour : MonoBehaviour {
    private Text countText;

    private void OnValidate() {
        countText = GetComponent<Text>();
        countText.text = "# Creatures: 10";
    }

    private void Awake() {
        countText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        countText.text = "# Creatures: " + StatsManager.Instance.CreatureValues.Count.ToString();
    }
}
