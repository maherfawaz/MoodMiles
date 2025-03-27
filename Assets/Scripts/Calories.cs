using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Accelerometer))]
public class Calories : MonoBehaviour
{
    // https://www.calculator.net/calories-burned-calculator.html
    [Header("Inscribed")]
    public float weight;
    public float speed;
    public float duration;


    [Header("Dynamic")]
    public int caloriesBurned;
    public float metValue;
    
    void Start() {
        // Example: Calculate calories burned for a 70 kg person running at 8 km/h for 30 minutes
        weight = 70; // in kg
        speed = 8; // in km/h
        duration = 30; // in minutes

        // MET value for running at 8 km/h is approximately 9.8
        metValue = 9.8f;
        
        // Calculate calories burned using the formula: Calories = MET * weight (kg) * duration (hours)
        caloriesBurned = Mathf.RoundToInt(metValue * weight * (duration / 60));
        
        Debug.Log("Calories burned: " + caloriesBurned);
    }
}
