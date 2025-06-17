using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Rewards : MonoBehaviour
{
    public static int reward = 0;
    public TextMeshProUGUI counterTMP;

    void Update()
    {
        if (counterTMP == null)
        {
            return;
        }
        counterTMP.text = reward.ToString();
    }
    
    public void Gain()
    {
        reward += 50;
        PlayGamesManager.Instance.SaveData();
        if (StaticHp.totalHP > 0)
        {
            SceneManager.LoadScene("Quaid Base");
        }
        if (StaticHp.totalHP <= 0)
        {
            Snooze.mission = true;
            Snooze.progress = false;
            Snooze.attack = false;
            Snooze.finish = false;
            Dashie.mission = true;
            Dashie.progress = false;
            Dashie.attack = false;
            Dashie.finish = false;
            Bruno.mission = true;
            Bruno.progress = false;
            Bruno.attack = false;
            Bruno.finish = false;
            Zippy.mission = true;
            Zippy.progress = false;
            Zippy.attack = false;
            Zippy.finish = false;
            NewStepCounter.lastStepOffset = 0;
            NewStepCounter.lastStepsTaken = 0;
            Calories.lastCaloriesBurned = 0;
            Calories.caloriesBurned = 0;
            Sleep.timeRemaining = 0;
            StaticHp.totalHP = 4;
            PlayGamesManager.Instance.SaveData();
            SceneManager.LoadScene("Jail Cutsceen");
        }
    }
}
