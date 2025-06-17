using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetUp : MonoBehaviour
{
    [Header("Inscribed")]
    public long initialStepGoal;
    public long stepGoalModifier;
    public int weightKg;
    public Slider slider;
    public TextMeshProUGUI sliderText;
    public TextMeshProUGUI stepGoalText;
    public TextMeshProUGUI caloriesGoalText;
    public TextMeshProUGUI sleepHoursText;

    [Header("Dynamic")]
    public static long finalStepGoal;
    public static long finalStepGoalModifier;
    public static long secondFinalStepGoalModifier = 1000;
    public static int finalCaloriesGoal = 150;
    public static int finalCaloriesGoalModifier = -50;

    void Start() {
        Sleep.hours = 6;
    }

    public void InitialSteps() {
        finalStepGoal = initialStepGoal;
    }
    
    public void InitialCalories() {
        switch (slider.value) {
            case 0:
                finalCaloriesGoal = 0;
                break;
            case 1:
                finalCaloriesGoal = 50;
                break;
            case 2:
                finalCaloriesGoal = 150;
                break;
            case 3:
                finalCaloriesGoal = 200;
                break;
            case 4:
                finalCaloriesGoal = 300;
                break;
        }
    }
    
    public void SleepHours() {
        Sleep.hours = slider.value;
        sliderText.text = slider.value + " hrs";
    }
    
    public void StepGoalModifier() {
        if (slider != null) {
            switch (slider.value) {
                case 0:
                    secondFinalStepGoalModifier = 0;
                    break;
                case 1:
                    secondFinalStepGoalModifier = 0;
                    break;
                case 2:
                    secondFinalStepGoalModifier = 1000;
                    break;
                case 3:
                    secondFinalStepGoalModifier = 1500;
                    break;
                case 4:
                    secondFinalStepGoalModifier = 2000;
                    break;
            }
        } else {
            finalStepGoalModifier = stepGoalModifier;
        }
    }

    public void CaloriesGoalModifier() {
        switch (slider.value) {
            case < 4:
                finalCaloriesGoalModifier = 0;
                break;
            case < 8:
                finalCaloriesGoalModifier = -50;
                break;
            case > 8:
                finalCaloriesGoalModifier = -100;
                break;
        }
        sliderText.text = slider.value + " hrs";
        Debug.Log("Final Calories Goal Modifier: " + finalCaloriesGoalModifier);
    }
    
    public void Weight() {
        string weightString = GetComponent<TMP_InputField>().text;
        weightKg = int.Parse(weightString);
        if (weightKg == 0) {
            Calories.weightKg = 70; // Default weight if not set
        } else {
            Calories.weightKg = weightKg;
        }
    }
    
    public void FinishSetup() {
        NewStepCounter.stepGoal = finalStepGoal + finalStepGoalModifier + secondFinalStepGoalModifier;
        Calories.caloriesGoal = finalCaloriesGoal + finalCaloriesGoalModifier;
        if (Calories.caloriesGoal <= 0) {
            Calories.caloriesGoal = 20;
        }
        if (NewStepCounter.stepGoal <= 0) {
            NewStepCounter.stepGoal = 500;
        }
        stepGoalText.text = $"{NewStepCounter.stepGoal}";
        caloriesGoalText.text = $"{Calories.caloriesGoal}";
        sleepHoursText.text = $"{Sleep.hours}";
    }
}
