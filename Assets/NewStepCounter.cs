using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

// https://discussions.unity.com/t/how-do-i-track-my-user-s-steps-while-app-is-minimised/351827
public class NewStepCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterTMP;
    private long stepOffset;
    private bool permissionGranted = false;

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
        } else {
            long currentSteps = StepCounter.current.stepCounter.ReadValue();
            long stepsTaken = currentSteps - stepOffset;
            counterTMP.text = "Steps: " + stepsTaken;
        }
    }

    async void RequestPermission() {
#if UNITY_EDITOR
        Debug.Log("Editor Platform");
#endif
#if UNITY_ANDROID
        AndroidRuntimePermissions.Permission result = await AndroidRuntimePermissions.RequestPermissionAsync("android.permission.ACTIVITY_RECOGNITION");
        if (result == AndroidRuntimePermissions.Permission.Granted) {
            permissionGranted = true;
            Debug.Log("Permission granted");
            InputSystem.EnableDevice(StepCounter.current);
        } else {
            Debug.Log("Permission denied");
        }
#endif
    }

    void OnApplicationPause(bool pause) {
        if (!pause && permissionGranted) {
            // Reinitialize the step counter when the app is resumed
            InputSystem.EnableDevice(StepCounter.current);
        }
    }
  }
