using UnityEngine;
using GooglePlayGames.BasicApi.SavedGame;

public class StepDataHandler : MonoBehaviour
{
    // https://medium.com/@xavidevsama/create-a-simple-step-counter-pedometer-with-unity-c-a68151354b82
    // Singleton setup (similar to StepCounter)
    private static StepDataHandler _instance;
    public static StepDataHandler Instance {
        get {
            if (_instance == null) {
                _instance = FindFirstObjectByType<StepDataHandler>();
                if (_instance == null) {
                    GameObject container = new GameObject("StepDataHandler");
                    _instance = container.AddComponent<StepDataHandler>();
                }
            }
            return _instance;
        }
    }
    private const string lastRecordedDateKey = "LastRecordedDate";
    private const string dailyStepsKey = "DailySteps";

    public void SaveDailySteps(int stepCount) {
        PlayerPrefs.SetInt(dailyStepsKey, stepCount);
    }

    public void CheckForNewDay() {
        string currentDateString = System.DateTime.Now.ToString("yyyyMMdd");
        string lastRecordedDate = PlayerPrefs.GetString(lastRecordedDateKey, currentDateString);
        if (currentDateString != lastRecordedDate) {
            ResetDailySteps();
            PlayerPrefs.SetString(lastRecordedDateKey, currentDateString);
        }
        else {
            LoadDailySteps();
        }
    }

    void ResetDailySteps() {
        PlayerPrefs.SetInt(dailyStepsKey, 0);
        OldStepCounter.Instance.ResetStepData();
        Debug.Log("New day, new steps! Counter reset.");
    }

    void LoadDailySteps() {
        int stepCount = PlayerPrefs.GetInt(dailyStepsKey, 0);
        OldStepCounter.Instance.LoadStepData(stepCount);
        Debug.Log("Loaded steps from your last adventure.");
    }
}
