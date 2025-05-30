using UnityEngine;
using UnityEngine.SceneManagement;

public class SetUp : MonoBehaviour
{
    [Header("Inscribed")]
    public long initialStepGoal;
    public long stepGoalModifier;
    public int initialCaloriesGoal;
    public int caloriesGoalModifier;
    public float sleepHours;

    public void InitialSteps() {
        NewStepCounter.stepGoal = initialStepGoal;
    }
    
    public void InitialCalories() {
        Calories.caloriesGoal = initialCaloriesGoal;
    }
    
    public void SleepHours() {
        Sleep.hours = sleepHours;
    }
    
    public void StepGoalModifier() {
        NewStepCounter.stepGoal += stepGoalModifier;
    }

    public void CaloriesGoalModifier() {
        Calories.caloriesGoal += caloriesGoalModifier;
    }
    
    public void FinishSetup() {
        if (PlayGamesManager.Instance != null) {
            PlayGamesManager.Instance.SaveData();
        }
        SceneManager.LoadScene(2);
    }
}
