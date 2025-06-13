using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bruno : MonoBehaviour
{
    public static bool intro = false;
    public static bool mission = false;
    public static bool progress = false;
    public static bool attack = false;
    public static bool finish = false;
    public static bool skipTu = false;
    public GameObject mis;
    public GameObject prog;
    public GameObject missionObj;
    public GameObject tu;
    public GameObject hat;
    public GameObject ready;
    public GameObject talkM;
    public GameObject talkP;
    public GameObject talkF;
    public TextMeshProUGUI counterTMP;
    public TextMeshProUGUI challengeGoalTMP;
    public TextMeshProUGUI missionTMP;

    void Start()
    {
        challengeGoalTMP.text = $"{Calories.caloriesGoal} calories";
        missionTMP.text = $"Fuel your day by burning {Calories.caloriesGoal} calories";
    } 

    void Update()
    {
        if (Hat.BhatsOn == true)
        {
            hat.SetActive(true);
        }
        if (Hat.BhatsOn == false)
        {
            hat.SetActive(false);
        }
        if (attack == true)
        {
            ready.SetActive(true);
            talkP.SetActive(false);
            talkF.SetActive(true);
        }
        else if (progress == true)
        {
            mis.SetActive(false);
            prog.SetActive(true);
            ready.SetActive(false);
            talkM.SetActive(false);
            talkP.SetActive(true);
            if (Calories.caloriesBurned > Calories.lastCaloriesBurned)
            {
                counterTMP.text = $"{Calories.lastCaloriesBurned}/{Calories.caloriesGoal}";
                Calories.lastCaloriesBurned = Calories.caloriesBurned; // Update the lastCaloriesBurned value
            }
        }
        else if (mission == true)
        {
            mis.SetActive(true);
            prog.SetActive(false);
            ready.SetActive(false);
            talkM.SetActive(true);
            talkF.SetActive(false);
        }
        else
        {
            ready.SetActive(false);
        }
    }

    public void ButtonStart()
    {
        mission = false;
        progress = true;
    }
    
    public void Zipp()
    {
        if (mission == true)
        {
            missionObj.SetActive(true);
        }

        if (attack == true)
        {
            if (skipTu == false)
            {
                tu.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("Quaid Bear Attack");
            }
        }
    }
}
