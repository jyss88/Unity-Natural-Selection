using System.Collections.Generic;

public class Subject {
    private List<Observer> observers = new List<Observer>();

    // Notify all observers
    public void Notify() {
        foreach(Observer observer in observers) {
            observer.OnNotify();
        }
    }

    public void AddObserver(Observer observer) {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer observer) {
        observers.Remove(observer);
    }
}
