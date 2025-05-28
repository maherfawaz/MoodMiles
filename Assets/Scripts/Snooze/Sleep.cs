using UnityEngine;
using TMPro;

// https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
public class Sleep : MonoBehaviour
{
    [Header("Inscribed")]
    public float hours;
    public GameObject stop;
    public static float ours;
    
    public TextMeshProUGUI timerText;

    [Header("Dynamic")]
    public float timeRemaining;
    public static float tr;
    public bool timerIsRunning = false;


    void Start()
    {
        if (PlayGamesManager.Instance != null) {
            hours = PlayGamesManager.Instance.data.sleepGoal;
            if (PlayGamesManager.Instance.data.sleepTimeRemaining > 0) {
                timeRemaining = PlayGamesManager.Instance.data.sleepTimeRemaining;
            } else {
                timeRemaining = hours * 3600;
            }
        } else {
            timeRemaining = hours * 3600;
        }
        ours = timeRemaining;
    }

    void Update() {
        tr = timeRemaining;
        if (timerIsRunning) {
            if (timeRemaining > 0) {
                stop.SetActive(false);
                timeRemaining -= Time.deltaTime;
                if (PlayGamesManager.Instance != null) {
                    PlayGamesManager.Instance.data.sleepTimeRemaining = timeRemaining;
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
