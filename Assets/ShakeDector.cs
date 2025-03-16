using UnityEngine;
[RequireComponent(typeof(dogManager))]
public class ShakeDector : MonoBehaviour
{
    public float ShakeDetectionThreshold;
    public float MinShakeInterval;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;

    private dogManager DogManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        DogManager = GetComponent<dogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
        {
            DogManager.ShakeRigidbodies(Input.acceleration);
            timeSinceLastShake = Time.unscaledTime;
        }
    }
}
