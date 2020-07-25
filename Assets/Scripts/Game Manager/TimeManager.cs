using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Text sliderText;

    private float playbackSpeed = 1f;

    public static bool IsPaused { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Pause();
        pauseButton.interactable = false;
        playButton.interactable = true;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        IsPaused = true;

        // Switch button states
        pauseButton.interactable = false;
        playButton.interactable = true;

        Debug.Log("Game Paused");
    }

    public void Resume()
    {
        Time.timeScale = playbackSpeed;
        IsPaused = false;

        pauseButton.interactable = true;
        playButton.interactable = false;

        Debug.Log("Game resumed");
    }

    public void ChangeSpeed(float newSpeed)
    {
        playbackSpeed = newSpeed;

        if (!IsPaused) { // Set timescale if playing
            Time.timeScale = newSpeed;
        }
        
        sliderText.text = playbackSpeed.ToString("F2") + "X";
    }
}
