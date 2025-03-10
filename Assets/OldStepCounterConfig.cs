using UnityEngine;

// https://medium.com/@xavidevsama/create-a-simple-step-counter-pedometer-with-unity-c-a68151354b82
[CreateAssetMenu(fileName = "OldStepCounterConfig", menuName = "OldStepCounter/Config", order = 1)]
public class OldStepCounterConfig : ScriptableObject
{
    [Header("Step Counter Settings")]
    [Tooltip("Average step length in meters.")]
    public float stepLength = 0.75f;

    [Header("Detection Settings")]
    [Tooltip("Acceleration threshold for detecting steps.")]
    public float threshold = 1f;
}
