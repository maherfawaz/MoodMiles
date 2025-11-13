using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dashie : MonoBehaviour
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
    public GameObject ready;
    public GameObject talkM;
    public GameObject talkP;
    public GameObject talkF;
    public GameObject hat;
    public TextMeshProUGUI counterTMP;
    public TextMeshProUGUI challengeGoalTMP;
    public TextMeshProUGUI missionTMP;
    public GameObject hatPrice;

    void Start()
    {
        missionTMP.text = $"Daily Dash: conquer {NewStepCounter.stepGoal} steps!";
        challengeGoalTMP.text = $"{NewStepCounter.stepGoal} steps";
    }

    void Update()
    {
        if (Hat.DhatsOn == true)
        {
            hat.SetActive(true);
        }
        if (Hat.DhatsOn == false)
        {
            hat.SetActive(false);
        }
        if (attack == true)
        {
            mis.SetActive(false);
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
            counterTMP.text = $"{NewStepCounter.lastStepsTaken}/{NewStepCounter.stepGoal}";
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
        if (Hat.hatUnlocked)
        {
            hatPrice.SetActive(false);
        }
    }

    public void StartMission()
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
                SceneManager.LoadScene("Quaid Dog Attack");
            }
        }
    }
}
