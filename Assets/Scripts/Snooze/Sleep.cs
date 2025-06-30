using UnityEngine;
using UnityEngine.SceneManagement;

// https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
public class Sleep : MonoBehaviour
{
    [Header("Dynamic")]
    public static float timeRemaining;
    public static float hours = 0.008f;
    public static float timeRemainingMinutes;
    public static float timeRemainingHours;


    void Start() {
        if (timeRemaining == 0) {
            timeRemaining = hours * 3600;
        }
        if (Snooze.progress == true) {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            GameObject.Find("Music").GetComponent<AudioSource>().Pause();
            SceneManager.LoadScene("Snooze Home");
        }
    }

    void Update() {
        if (Snooze.progress == true) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                PlayGamesManager.Instance.SaveData();
                timeRemainingMinutes = timeRemaining / 60;
                timeRemainingHours = timeRemaining / 3600;
            } else {
                Debug.Log("Time has run out!");
                Screen.sleepTimeout = SleepTimeout.SystemSetting;
                GameObject.Find("Music").GetComponent<AudioSource>().UnPause();
                timeRemaining = 0;
            }
        }
    }
}
