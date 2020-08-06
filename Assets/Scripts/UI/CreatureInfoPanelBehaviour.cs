using UnityEngine;
using UnityEngine.EventSystems;

public class CreatureInfoPanelBehaviour : MonoBehaviour {
    public ICreature Creature { get; set; }

    private Subject panelSubject = new Subject();

    private void Awake() {
        EventSystem.current.SetSelectedGameObject(gameObject);

        foreach (Observer observer in GetComponentsInChildren<Observer>()) {
            panelSubject.AddObserver(observer);
        }
    }

    private void OnEnable() {
        panelSubject.Notify();
    }

    private void OnDisable() {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Creature != null) {

        } else if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        }
    }

    public void NotifySubject() {
        panelSubject.Notify();
    }
}
