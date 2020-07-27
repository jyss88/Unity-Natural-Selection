using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CreatureClickBehaviour : MonoBehaviour, IPointerClickHandler {
    [SerializeField] private GameObject panel;
    private CreatureInfoPanelBehaviour panelBehaviour;
    private CreatureBehaviour creature;

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("Clicked on creature");
        panelBehaviour.Creature = creature;
        panel.SetActive(!panel.activeSelf);
    }

    // Start is called before the first frame update
    void Awake() {
        creature = GetComponent<CreatureBehaviour>();
        panelBehaviour = panel.GetComponent<CreatureInfoPanelBehaviour>();
    }
}
