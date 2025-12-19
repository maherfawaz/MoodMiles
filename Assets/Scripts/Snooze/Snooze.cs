using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Snooze : MonoBehaviour
{
    public static bool intro = false;
    public static bool mission = false;
    public static bool progress = false;
    public static bool attack = false;
    public static bool finish = false;
    public static bool skipTu = false;
    public GameObject mis;
    public GameObject prog;
    public GameObject count;
    public GameObject main;
    public GameObject hat;
    public GameObject missionObj;
    public GameObject tu;
    public GameObject ready;
    public GameObject talkM;
    public GameObject talkP;
    public GameObject talkF;
    public GameObject stop;
    public GameObject homeButtons;
    public GameObject island;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI challengeGoalText;
    public TextMeshProUGUI missionText;
    public GameObject hatPrice;

    void Start()
    {
        if (mission == true)
        {
            mis.SetActive(true);
            count.SetActive(false);
            main.GetComponent<Camera>().backgroundColor = new Color(178f / 255f, 208f / 255f, 255f / 255f);
        }
        if (Sleep.hours > 0.016f)
        {
            challengeGoalText.text = $"Sleep {Sleep.hours} hours";
            missionText.text = $"Recharge by aiming for at least {Sleep.hours} hours of sleep";
        }
    }

    void Update()
    {
        if (Hat.hatsOn == true)
        {
            hat.SetActive(true);
        }
        else if (Hat.hatsOn == false)
        {
            hat.SetActive(false);
        }
        if (attack == true)
        {
            ready.SetActive(true);
            talkP.SetActive(false);
            talkF.SetActive(true);
            homeButtons.SetActive(true);
            island.SetActive(true);
            main.GetComponent<Camera>().backgroundColor = new Color(178f / 255f, 208f / 255f, 255f / 255f);
        }
        else if (progress == true)
        {
            mis.SetActive(false);
            prog.SetActive(true);
            count.SetActive(true);
            ready.SetActive(false);
            talkM.SetActive(false);
            talkP.SetActive(true);
            homeButtons.SetActive(false);
            island.SetActive(false);
            main.GetComponent<Camera>().backgroundColor = new Color(16f / 255f, 78f / 255f, 111f / 255f);
            if (Sleep.timeRemaining > 0)
            {
                stop.SetActive(false);
                timerText.text = string.Format("{0:00}:{1:00}:{2:00}", (int)Sleep.timeRemainingHours, (int)Sleep.timeRemainingMinutes % 60, (int)Sleep.timeRemaining % 60);
            }
            else
            {
                stop.SetActive(true);
            }
        }
        else if (mission == true)
        {
            ready.SetActive(false);
            talkM.SetActive(true);
            talkF.SetActive(false);
        }
        else
        {
            ready.SetActive(false);
            main.GetComponent<Camera>().backgroundColor = new Color(178f / 255f, 208f / 255f, 255f / 255f);
        }
        if (Hat.hatUnlocked)
        {
            hatPrice.SetActive(false);
        }
    }

    public void StopTimer()
    {
        progress = false;
        attack = true;
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
        GameObject.Find("Music").GetComponent<AudioSource>().UnPause();
    }

    public void StartTimer()
    {
        mission = false;
        progress = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        GameObject.Find("Music").GetComponent<AudioSource>().Pause();
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
                SceneManager.LoadScene("Quaid Sloth Click");
            }
        }
    }
}
