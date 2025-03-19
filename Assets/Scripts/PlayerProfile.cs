using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    // https://medium.com/@xavidevsama/create-a-simple-step-counter-pedometer-with-unity-c-a68151354b82
    // Singleton setup (similar to StepCounter)
    private static PlayerProfile _instance;
    public static PlayerProfile Instance {
        get {
            if (_instance == null) {
                _instance = FindFirstObjectByType<PlayerProfile>();
                if (_instance == null) {
                    GameObject container = new GameObject("PlayerProfile");
                    _instance = container.AddComponent<PlayerProfile>();
                }
            }
            return _instance;
        }
    }
    [Header("Inscribed")]
    public int stepsGoal;
    public int sleepTime;

    [Header("Dynamic")]
    private const string questionsAnsweredKey = "QuestionsAnswered";
    private const string stepsGoalKey = "StepsGoal";
    private const string sleepTimeKey = "SleepTime";

    void Start() {
        DontDestroyOnLoad(gameObject);
        if (PlayerPrefs.HasKey(questionsAnsweredKey)) {
            if (PlayerPrefs.GetString(questionsAnsweredKey) == "Yes") {
                stepsGoal = PlayerPrefs.GetInt(stepsGoalKey);
                sleepTime = PlayerPrefs.GetInt(sleepTimeKey);
            }
        }
    }

    public void SaveData() {
        PlayerPrefs.SetInt(stepsGoalKey, stepsGoal);
        PlayerPrefs.SetInt(sleepTimeKey, sleepTime);
    }

    public void QuestionsAnswered() {
        PlayerPrefs.SetString(questionsAnsweredKey, "Yes");
    }
}