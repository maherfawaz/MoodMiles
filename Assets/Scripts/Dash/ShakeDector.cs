using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(dogManager))]

public class ShakeDector : MonoBehaviour
{
    public float ShakeDetectionThreshold;
    public float MinShakeInterval;

    private Vector3 accel;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;

    private dogManager DogManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        DogManager = GetComponent<dogManager>();

        if (Application.isEditor)
        {
            Debug.Log("Running in Editor");
            return;
        }

        InputSystem.EnableDevice(Accelerometer.current);
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor)
        {
            return;
        }

        if (Accelerometer.current == null)
        {
            Debug.Log("Accelerometer not available");
            return;
        }

        accel = Accelerometer.current.acceleration.ReadValue();
        
        if (accel.sqrMagnitude >= sqrShakeDetectionThreshold && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
        {
            DogManager.ShakeRigidbodies(accel);
            timeSinceLastShake = Time.unscaledTime;
        }
    }

    void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // Reinitialize the accelerometer when the app is resumed
            InputSystem.EnableDevice(Accelerometer.current);
        }
    }
}
