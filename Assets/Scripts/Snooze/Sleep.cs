using UnityEngine;
using TMPro;

// https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
public class Sleep : MonoBehaviour
{
    [Header("Inscribed")]
    public static float hours = 0.016f;
    public GameObject stop;
    public static float ours;
    public TextMeshProUGUI timerText;

    [Header("Dynamic")]
    public static float timeRemaining;
    public static float tr;
    public bool timerIsRunning = false;


    void Start()
    {
        if (timeRemaining == 0) {
            timeRemaining = hours * 3600;
        }
        ours = timeRemaining;
    }

    void Update() {
        tr = timeRemaining;
        if (Snooze.progress == true) {
            if (timeRemaining > 0) {
                stop.SetActive(false);
                timeRemaining -= Time.deltaTime;
                if (PlayGamesManager.Instance != null) {
                    PlayGamesManager.Instance.SaveData();
                }
                float timeRemainingMinutes = timeRemaining / 60;
                float timeRemainingHours = timeRemaining / 3600;
                timerText.text = string.Format("{0:00}:{1:00}:{2:00}", (int)timeRemainingHours, (int)timeRemainingMinutes % 60, (int)timeRemaining % 60);
            } else {
                Debug.Log("Time has run out!");
                stop.SetActive(true);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void StartSleepTimer() {
        timerIsRunning = true;
    }
}
