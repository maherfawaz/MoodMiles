using UnityEngine;
using UnityEngine.InputSystem;

public class Calories : MonoBehaviour
{
    // https://www.calculator.net/calories-burned-calculator.html
    [Header("Dynamic")]
    public float speed;
    public float duration;
    public float time;
    public float metValue;
    public Vector3 accel;
    public static int caloriesBurned;
    public static int caloriesGoal = 20;
    public static int weightKg = 70;
    public static int lastCaloriesBurned = -1; // Tracks the last updated calories burned value
    
    void Start() {
        if (Application.isEditor) {
            Debug.Log("Running in Editor");
            return;
        }

        InputSystem.EnableDevice(Accelerometer.current);
    }

    void Update() {
        if (Bruno.progress == true) {
            if (Application.isEditor) {
                return;
            }

            if (Accelerometer.current == null) {
                Debug.Log("Accelerometer not available");
                return;
            }

            accel = Accelerometer.current.acceleration.ReadValue();
            time += Time.deltaTime;
            duration = time / 60; // Convert seconds to minutes
            speed = Mathf.Sqrt(accel.x * accel.x + accel.y * accel.y + accel.z * accel.z) * 3.6f; // Convert m/s to km/h
                                                                                                  // Calculate MET value based on speed (in km/h)
            switch (speed) {
                case < 4:
                    metValue = 2.5f; // Walking at 2 mph (3.2 km/h)
                    break;
                case < 6:
                    metValue = 3.5f; // Walking at 4 mph (6.4 km/h)
                    break;
                case < 8:
                    metValue = 5.0f; // Jogging at 6 mph (9.7 km/h)
                    break;
                default:
                    metValue = 8.0f; // Running at 8 mph (12.9 km/h)
                    break;
            }
            // Calculate calories burned using the formula: Calories = MET * weight (kg) * duration (hours)
            caloriesBurned = Mathf.RoundToInt(metValue * weightKg * (duration / 60)); // Convert duration from minutes to hours
            
            PlayGamesManager.Instance.SaveData();

            if (caloriesBurned >= caloriesGoal) { // Completing mission once goal is reached
                Bruno.progress = false;
                Bruno.attack = true;
            }
        }
        
    }

    void OnApplicationPause(bool pause) {
        if (!pause) {
            // Reinitialize the accelerometer when the app is resumed
            InputSystem.EnableDevice(Accelerometer.current);
        }
    }
}
