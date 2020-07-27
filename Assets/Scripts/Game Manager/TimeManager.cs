using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class handling simulation time
/// </summary>
public class TimeManager : MonoBehaviour {
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Text sliderText;

    private float playbackSpeed = 1f;

    public static bool IsPaused { get; private set; }

    // Start is called before the first frame update
    void Start() {
        Pause();
        pauseButton.interactable = false;
        playButton.interactable = true;
    }

    /// <summary>
    /// Pauses simulation
    /// </summary>
    public void Pause() {
        Time.timeScale = 0f;
        IsPaused = true;

        // Switch button states
        pauseButton.interactable = false;
        playButton.interactable = true;

        Debug.Log("Game Paused");
    }

    /// <summary>
    /// Resumes simulation
    /// </summary>
    public void Resume() {
        Time.timeScale = playbackSpeed;
        IsPaused = false;

        pauseButton.interactable = true;
        playButton.interactable = false;

        Debug.Log("Game resumed");
    }

    /// <summary>
    /// Changes playback speed
    /// </summary>
    /// <param name="newSpeed">New speed value</param>
    public void ChangeSpeed(float newSpeed) {
        playbackSpeed = newSpeed;

        if (!IsPaused) { // Set timescale if playing
            Time.timeScale = newSpeed;
        }

        sliderText.text = playbackSpeed.ToString("F2") + "X";
    }
}