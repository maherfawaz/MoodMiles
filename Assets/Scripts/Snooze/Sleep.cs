using UnityEngine;
using TMPro;

// https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
public class Sleep : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject stop;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI challengeGoalText;
    public TextMeshProUGUI missionText;

    [Header("Dynamic")]
    public static float timeRemaining;
    public static float tr;
    public static float hours = 0.016f;
    public static float ours;


    void Start() {
        if (timeRemaining == 0) {
            timeRemaining = hours * 3600;
        }
        if (hours > 0.016f) {
            challengeGoalText.text = $"Sleep {hours} hours";
            missionText.text = $"Recharge by aiming for at least {hours} hours of sleep";
        }
        ours = timeRemaining;
    }

    void Update() {
        tr = timeRemaining;
        if (Snooze.progress == true) {
            if (timeRemaining > 0) {
                stop.SetActive(false);
                timeRemaining -= Time.deltaTime;
                PlayGamesManager.Instance.SaveData();
                float timeRemainingMinutes = timeRemaining / 60;
                float timeRemainingHours = timeRemaining / 3600;
                timerText.text = string.Format("{0:00}:{1:00}:{2:00}", (int)timeRemainingHours, (int)timeRemainingMinutes % 60, (int)timeRemaining % 60);
            } else {
                Debug.Log("Time has run out!");
                stop.SetActive(true);
                timeRemaining = 0;
            }
        }
    }
}
