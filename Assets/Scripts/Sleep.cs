using UnityEngine;
using TMPro;

// https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
public class Sleep : MonoBehaviour
{
    [Header("Inscribed")]
    public int hours;

    [Header("Dynamic")]
    public TextMeshProUGUI timerText;
    public float timeRemaining;
    public bool timerIsRunning = false;

    void Start() {
        timeRemaining = hours * 3600;
        timerText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update() {
        if (timerIsRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                float timeRemainingMinutes = timeRemaining / 60;
                float timeRemainingHours = timeRemaining / 3600;
                timerText.text = string.Format("{0:00}:{1:00}:{2:00}", (int)timeRemainingHours, (int)timeRemainingMinutes % 60, (int)timeRemaining % 60);
            } else {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void StartSleepTimer() {
        timerIsRunning = true;
    }
}
