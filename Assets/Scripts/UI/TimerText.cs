using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    [SerializeField] private Text timerLabel;

    private float startTime;
    private string minutes;
    private string seconds;

    // Start is called before the first frame update
    void Start()
    {
        timerLabel.text = "00:00";
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time - startTime;
        minutes = Mathf.Floor(currentTime / 60).ToString("00");
        seconds = (currentTime % 60).ToString("00");

        timerLabel.text = string.Format("{0}:{1}", minutes, seconds);
    }
}
