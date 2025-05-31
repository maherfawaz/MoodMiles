using UnityEngine;
using TMPro;

public class SetUp : MonoBehaviour
{
    [Header("Inscribed")]
    public long initialStepGoal;
    public long stepGoalModifier;
    public int initialCaloriesGoal;
    public int caloriesGoalModifier;
    public float sleepHours;
    public int weightKg;

    [Header("Dynamic")]
    public static long finalStepGoal;
    public static long finalStepGoalModifier;
    public static int finalCaloriesGoal;
    public static int finalCaloriesGoalModifier;

    public void InitialSteps() {
        finalStepGoal = initialStepGoal;
    }
    
    public void InitialCalories() {
        finalCaloriesGoal = initialCaloriesGoal;
    }
    
    public void SleepHours() {
        Sleep.hours = sleepHours;
    }
    
    public void StepGoalModifier() {
        finalStepGoalModifier = stepGoalModifier;
    }

    public void CaloriesGoalModifier() {
        finalCaloriesGoalModifier = caloriesGoalModifier;
    }
    
    public void Weight() {
        string weightString = GetComponent<TMP_InputField>().text;
        weightKg = int.Parse(weightString);
        Calories.weightKg = weightKg;
    }
    
    public void FinishSetup() {
        NewStepCounter.stepGoal = finalStepGoal + finalStepGoalModifier;
        Calories.caloriesGoal = finalCaloriesGoal + finalCaloriesGoalModifier;
        if (PlayGamesManager.Instance != null) {
            PlayGamesManager.Instance.SaveData();
        }
    }
}
