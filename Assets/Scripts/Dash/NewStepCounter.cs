using UnityEngine;
using UnityEngine.InputSystem;

// https://discussions.unity.com/t/how-do-i-track-my-user-s-steps-while-app-is-minimised/351827
public class NewStepCounter : MonoBehaviour
{
    [Header("Dynamic")]
    [Tooltip("The total amount of steps walked since the last time the device was booted.")]
    public long currentStepOffset;
    [Tooltip("The total amount of steps taken by the user since the last time they played the game.")]
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
        if (lastStepsTaken > 0) { // Loads number of steps taken according to player save data
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

            if (currentStepOffset == 0) { // Initial check of device step counter
                currentStepOffset = StepCounter.current.stepCounter.ReadValue();
                if (currentStepOffset > lastStepOffset && lastStepOffset != 0) { // If the player has taken steps since last boot, add those to stepsTaken
                    stepsTaken += currentStepOffset - lastStepOffset;
                }
            } else { // Steps actively tracked here
                // These offsets are used because the device step counter tracks the amount a user has walked since last device boot
                lastStepOffset = StepCounter.current.stepCounter.ReadValue();
                lastStepsTaken = lastStepOffset - currentStepOffset + stepsTaken; // lastStepsTaken here should be the total of steps user has taken thus far, which is saved
                PlayGamesManager.Instance.SaveData();
            }

            if (lastStepsTaken >= stepGoal) { // Completing mission once goal is reached
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
