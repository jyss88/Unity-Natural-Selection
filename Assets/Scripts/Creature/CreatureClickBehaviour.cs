using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CreatureClickBehaviour : MonoBehaviour, IPointerClickHandler {
    [SerializeField] private GameObject panel;
    private CreatureInfoPanelBehaviour panelBehaviour;
    private ICreature creature;

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("Clicked on creature");
        panelBehaviour.Creature = creature;
        panel.SetActive(true);
        panel.GetComponent<CreatureInfoPanelBehaviour>().NotifySubject();
    }

    // Start is called before the first frame update
    void Awake() {
        creature = GetComponent<ICreature>();
        panelBehaviour = panel.GetComponent<CreatureInfoPanelBehaviour>();
    }
}
