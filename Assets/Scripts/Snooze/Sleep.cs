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
        if (timeRemaining == 0) { // Calculate start time in seconds
            timeRemaining = hours * 3600;
        }
        if (Snooze.progress == true) { // If player closes and reopens while mission is in progress, the player is returned to the Snooze Home scene
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
                timeRemainingMinutes = timeRemaining / 60; // Used to display timer UI
                timeRemainingHours = timeRemaining / 3600; // Used to display timer UI
            } else {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
            }
        }
    }

    void OnApplicationPause(bool pause) {
        if (Snooze.progress) {
            if (pause) {
                Screen.sleepTimeout = SleepTimeout.SystemSetting;
            } else {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }
        }
    }
}
