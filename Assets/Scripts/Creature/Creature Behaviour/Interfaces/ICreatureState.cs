public enum CState {
    wander,
    hunt
}
public interface ICreatureState {
    CState State { get; set; }
}
