using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Calories : MonoBehaviour
{
    // https://www.calculator.net/calories-burned-calculator.html
    [Header("Inscribed")]
    public int caloriesGoal = 1000;
    public int weight = 70; // in kg
    public float speed; // in km/h
    public float duration; // in minutes
    public float metValue = 5f;

    [Header("Dynamic")]
    public Vector3 accel;
    public int caloriesBurned;
    public bool permissionGranted = false;
    public TextMeshProUGUI counterTMP;
    
    void Start() {
        if (Application.isEditor) {
            Debug.Log("Running in Editor");
            return;
        }

        counterTMP = GameObject.Find("Calories").GetComponent<TextMeshProUGUI>();

        RequestPermission();
    }

    void Update() {
        if (Application.isEditor || !permissionGranted) {
            return;
        }

        if (Accelerometer.current == null) {
            Debug.Log("Accelerometer not available");
            return;
        }

        accel = Accelerometer.current.acceleration.ReadValue();
        speed = Mathf.Sqrt(accel.x * accel.x + accel.y * accel.y + accel.z * accel.z) * 3.6f; // Convert m/s to km/h
        duration = Time.deltaTime * 60; // Convert seconds to minutes
        // Calculate MET value based on speed (in km/h)
        if (speed < 4) {
            metValue = 2.5f; // Walking at 2 mph (3.2 km/h)
        } else if (speed < 6) {
            metValue = 3.5f; // Walking at 4 mph (6.4 km/h)
        } else if (speed < 8) {
            metValue = 5.0f; // Jogging at 6 mph (9.7 km/h)
        } else {
            metValue = 8.0f; // Running at 8 mph (12.9 km/h)
        }
        // Calculate calories burned using the formula: Calories = MET * weight (kg) * duration (hours)
        caloriesBurned = Mathf.RoundToInt(metValue * weight * (duration / 60));
        counterTMP.text = "Calories burned: " + caloriesBurned + "/" + caloriesGoal;
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
            InputSystem.EnableDevice(Accelerometer.current);
        } else {
            Debug.Log("Permission denied");
        }
#endif
    }

    void OnApplicationPause(bool pause) {
        if (!pause && permissionGranted) {
            // Reinitialize the accelerometer when the app is resumed
            InputSystem.EnableDevice(Accelerometer.current);
        }
    }
}
