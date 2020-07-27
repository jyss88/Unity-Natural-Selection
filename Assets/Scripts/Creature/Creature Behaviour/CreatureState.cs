/// <summary>
/// Class representing state of creature
/// </summary>
public class CreatureState : ICreatureState {
    /// <summary>
    /// State of creature
    /// </summary>
    public CState State { get; set; }

    /// <summary>
    /// Constructor for creature state
    /// </summary>
    public CreatureState() {
        State = CState.wander;
    }
}
