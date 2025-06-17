using UnityEngine;
using UnityEngine.InputSystem;

// https://discussions.unity.com/t/how-do-i-track-my-user-s-steps-while-app-is-minimised/351827
public class NewStepCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public long currentStepOffset;
    public long stepsTaken;
    public static long lastStepOffset;
    public static long lastStepsTaken;
    public static long stepGoal = 20;

    void Start() {
        if (Application.isEditor) {
            Debug.Log("Running in Editor");
            return;
        }

        InputSystem.EnableDevice(StepCounter.current);
        if (lastStepsTaken > 0) {
            stepsTaken = lastStepsTaken;
        }
    }

    void Update() {
        if (Dashie.progress == true) {
            
            if (Application.isEditor) {
                return;
            }

            if (StepCounter.current == null) {
                Debug.Log("StepCounter not available");
                return;
            }

            if (currentStepOffset == 0) {
                currentStepOffset = StepCounter.current.stepCounter.ReadValue();
                if (currentStepOffset > lastStepOffset && lastStepOffset != 0) {
                    stepsTaken += currentStepOffset - lastStepOffset;
                }
            } else {
                lastStepOffset = StepCounter.current.stepCounter.ReadValue();
                lastStepsTaken = lastStepOffset - currentStepOffset + stepsTaken;
                PlayGamesManager.Instance.SaveData();
            }

            if (lastStepsTaken >= stepGoal) {
                Dashie.progress = false;
                Dashie.attack = true;
                // Disable the step counter when the goal is reached
                InputSystem.DisableDevice(StepCounter.current);
            }
        }
        
    }

    void OnApplicationPause(bool pause) {
        if (!pause) {
            // Reinitialize the step counter when the app is resumed
            InputSystem.EnableDevice(StepCounter.current);
        }
    }
  }
