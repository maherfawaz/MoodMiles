using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

// https://discussions.unity.com/t/how-do-i-track-my-user-s-steps-while-app-is-minimised/351827
public class NewStepCounter : MonoBehaviour
{
    [Header("Inscribed")]
    public static long stepGoal = 20;
    public static float sg;
    public TextMeshProUGUI counterTMP;

    [Header("Dynamic")]
    public static long lastStepOffset;
    public static long stepsTaken;
    public static float st;
    public long currentStepOffset;
    public bool permissionGranted = false;
    public bool stepOn = false;

    void Start() {
        if (Application.isEditor) {
            Debug.Log("Running in Editor");
            return;
        }

        RequestPermission();
    }

    void Update() {
        sg = stepGoal;
        st = stepsTaken;
        if (Dashie.progress == true) {
            
            if (Application.isEditor || !permissionGranted) {
                return;
            }

            if (StepCounter.current == null) {
                Debug.Log("StepCounter not available");
                return;
            }

            if (currentStepOffset == 0) {
                currentStepOffset = StepCounter.current.stepCounter.ReadValue();
                if (currentStepOffset > lastStepOffset) { // A scuffed way to track steps walked when app is closed cause Unity won't let me, won't work if device is restarted
                    currentStepOffset = currentStepOffset - lastStepOffset;
                }
                Debug.Log("Step offset " + currentStepOffset);
            } else {
                lastStepOffset = StepCounter.current.stepCounter.ReadValue();
                stepsTaken = lastStepOffset - currentStepOffset;
                if (PlayGamesManager.Instance != null) {
                    PlayGamesManager.Instance.SaveData();
                }
                counterTMP.text = $"{stepsTaken}/{stepGoal}";
            }

            if (stepsTaken >= stepGoal) {
                counterTMP.text = "Goal reached!";
                Dashie.progress = false;
                Dashie.attack = true;
                // Disable the step counter when the goal is reached
                InputSystem.DisableDevice(StepCounter.current);
                stepOn = false;
            }
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

    public void StepsStart() {
        stepOn = true;
    }
  }
