using UnityEngine;
using UnityEngine.EventSystems;

public class CreatureClickBehaviour : MonoBehaviour, IPointerClickHandler {
    [SerializeField] private GameObject panel;
    [SerializeField] private KeyCode closeKey = KeyCode.Escape;

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

    private void Update() {
        CheckDeselect();
        panel.GetComponent<CreatureInfoPanelBehaviour>().NotifySubject();
    }

    public void CheckDeselect() {
        if(Input.GetKey(closeKey) && panel.activeSelf) {
            panel.SetActive(false);
        }
    }

    public void OnDestroy() {
        if(panelBehaviour.Creature == creature) {
            panelBehaviour.Creature = null;
            panel.SetActive(false);
        }        
    }
}
