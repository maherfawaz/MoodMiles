using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

// https://discussions.unity.com/t/how-do-i-track-my-user-s-steps-while-app-is-minimised/351827
public class NewStepCounter : MonoBehaviour
{
    [Header("Inscribed")]
    public long stepGoal;

    [Header("Dynamic")]
    public TextMeshProUGUI counterTMP;
    public long stepOffset;
    public long stepsTaken;
    public long currentSteps;
    public bool permissionGranted = false;
    public bool stepOn = false;

    void Start() {
        if (Application.isEditor) {
            Debug.Log("Running in Editor");
            return;
        }

        counterTMP = GameObject.Find("Steps").GetComponent<TextMeshProUGUI>();

        RequestPermission();
    }

    void Update() {
        if (stepOn == true)
        {
            if (Application.isEditor || !permissionGranted)
            {
                return;
            }

            if (StepCounter.current == null)
            {
                Debug.Log("StepCounter not available");
                return;
            }

            if (stepOffset == 0)
            {
                stepOffset = StepCounter.current.stepCounter.ReadValue();
                Debug.Log("Step offset " + stepOffset);
            }
            else
            {
                currentSteps = StepCounter.current.stepCounter.ReadValue();
                stepsTaken = currentSteps - stepOffset;
                counterTMP.text = "Steps: " + stepsTaken + "/" + stepGoal;
            }

            if (stepsTaken >= stepGoal)
            {
                counterTMP.text = "Goal reached!";
                Dashie.attack = true;
                // Disable the step counter when the goal is reached
                InputSystem.DisableDevice(StepCounter.current);
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

    public void StepsStart()
    {
        stepOn = true;
        
    }
  }
