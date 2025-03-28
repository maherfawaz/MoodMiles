using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Calories : MonoBehaviour
{
    // https://www.calculator.net/calories-burned-calculator.html
    [Header("Inscribed")]
    // Example: Calculate calories burned for a 70 kg person running at 8 km/h for 30 minutes
    public float weight = 70; // in kg
    public float speed = 8; // in km/h
    public float duration = 2; // in minutes


    [Header("Dynamic")]
    public int caloriesBurned;
    public float metValue;
    public bool permissionGranted = false;
    public TextMeshProUGUI counterTMP;
    
    void Start() {
        // MET value for running at 8 km/h is approximately 9.8
        metValue = 9.8f;
        counterTMP = GameObject.Find("Calories").GetComponent<TextMeshProUGUI>();
        RequestPermission();
    }

    void Update() {
        // Calculate calories burned using the formula: Calories = MET * weight (kg) * duration (hours)
        caloriesBurned = Mathf.RoundToInt(metValue * weight * (duration / 60));
        counterTMP.text = "Calories burned: " + caloriesBurned;
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
