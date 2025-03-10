using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Android;

public class NewStepCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counterTMP;
    public int simulatedSteps;
    public const float stepsPerKilometer = 1350.0f;
    long stepOffset;
    bool permissionGranted = false;

    void Start() {
        if (Application.isEditor) {
            Debug.Log("Running in Editor");
            return;
        }

        counterTMP = GameObject.Find("Steps").GetComponent<TextMeshProUGUI>();

        RequestPermission();
    }

    void Update() {
        if (Application.isEditor || !permissionGranted) {
            return;
        }

        if (StepCounter.current == null) {
            Debug.Log("StepCounter not available");
            return;
        }

        if (stepOffset == 0) {
            stepOffset = StepCounter.current.stepCounter.ReadValue();
            Debug.Log("Step offset " + stepOffset);
        }
        else {
            long currentSteps = StepCounter.current.stepCounter.ReadValue();
            long stepsTaken = currentSteps - stepOffset;
            counterTMP.text = "Steps: " + stepsTaken;

            /*try {
                Challenge.staticData.player.steps = (int)stepsTaken;
            }
            catch (OverflowException) {
                Debug.Log("Failure to convert long steps");
            }*/
        }
    }

    async void RequestPermission() {
#if UNITY_EDITOR
        Debug.Log("Editor Platform");
#endif
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION")) {
            Permission.RequestUserPermission("android.permission.ACTIVITY_RECOGNITION");
        }
        if (Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION")) {
            permissionGranted = true;
            Debug.Log("Permission granted");
            InitializeStepCounter();
        }
        else {
            Debug.Log("Permission denied");
        }
#endif
    }

    void InitializeStepCounter() {
        InputSystem.EnableDevice(StepCounter.current);
        stepOffset = StepCounter.current.stepCounter.ReadValue();
    }

    void OnApplicationPause(bool pause) {
        if (!pause && permissionGranted) {
            // Reinitialize the step counter when the app is resumed
            InitializeStepCounter();
        }
    }
  }
