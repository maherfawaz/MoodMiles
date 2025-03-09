using UnityEngine;
using UnityEngine.UI;

public class OldStepCounter : MonoBehaviour
{
    // https://medium.com/@xavidevsama/create-a-simple-step-counter-pedometer-with-unity-c-a68151354b82, https://youtu.be/o_2KMYLDdlw?si=3xszGHWfZyTYpk5c
    // Singleton setup
    private static OldStepCounter _instance;
    public static OldStepCounter Instance {
        get {
            if (_instance == null) {
                _instance = FindFirstObjectByType<OldStepCounter>();
                if (_instance == null) {
                    GameObject container = new GameObject("StepCounter");
                    _instance = container.AddComponent<OldStepCounter>();
                }
            }
            return _instance;
        }
    }

    [Header("Dynamic")]
    public Text stepsText;
    public Text distanceText;

    [Header("Configuration")]
    public StepCounterConfig config;
    [Header("Runtime Variables")]
    [SerializeField] private float distanceWalked = 0f;
    [SerializeField] private int stepCount = 0;
    private Vector3 acceleration;
    private Vector3 prevAcceleration;

    void Start() {
        if (config == null) {
            Debug.LogError("Oops! StepCounterConfig is missing!");
            return;
        }
        prevAcceleration = Input.acceleration;
        StepDataHandler.Instance.CheckForNewDay();
        stepsText = GameObject.Find("Steps").GetComponent<Text>();
        distanceText = GameObject.Find("Distance").GetComponent<Text>();
    }

    void Update() {
        if (config == null) return;
        DetectSteps();
        CalculateDistance();
        StepDataHandler.Instance.SaveDailySteps(stepCount);
        stepsText.text = $"Steps: {stepCount}";
        distanceText.text = $"Distance: {distanceWalked}m";
    }

    void DetectSteps() {
        acceleration = Input.acceleration;
        float delta = (acceleration - prevAcceleration).magnitude;
        if (delta > config.threshold)
        {
            stepCount++;
            Debug.Log($"Step detected! Count: {stepCount}");
        }
        prevAcceleration = acceleration;
    }
    
    void CalculateDistance() {
        distanceWalked = stepCount * config.stepLength;
    }

    public void CalibrateStepLength(float newStepLength) {
        if (newStepLength > 0) {
            config.stepLength = newStepLength;
            Debug.Log($"Step length calibrated to: {config.stepLength} meters");
        }
        else {
            Debug.LogWarning("Whoops! That's not a valid step length.");
        }
    }

    // Getter methods and data management
    public float GetDistanceWalked() => distanceWalked;
    public int GetStepCount() => stepCount;

    public void ResetStepData() {
        stepCount = 0;
        distanceWalked = 0f;
    }

    public void LoadStepData(int loadedStepCount) {
        stepCount = loadedStepCount;
        CalculateDistance();
    }
}
