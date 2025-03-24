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
    public GameObject bebut;
    public GameObject bibut;
    public GameObject sbu;
    public GameObject dbut;
  

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
                bebut.SetActive(false);
                bibut.SetActive(false);
                sbu.SetActive(false);
                dbut.SetActive(false);
            } else {
                Debug.Log("Time has run out!");
                SnoozeInro.mission = false;
                SnoozeInro.attack = true;
                timeRemaining = 0;
                bebut.SetActive(true);
                bibut.SetActive(true);
                sbu.SetActive(true);
                dbut.SetActive(true);
                timerIsRunning = false;
               
            }
        }
    }

    public void StartSleepTimer() {
        timerIsRunning = true;
    }
}
