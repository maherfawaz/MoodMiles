using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        if (mission == true)
        {
            mis.SetActive(true);
            count.SetActive(false);
            main.GetComponent<Camera>().backgroundColor = new Color(178f / 255f, 208f / 255f, 255f / 255f);
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
            main.GetComponent<Camera>().backgroundColor = new Color(16f / 255f, 78f / 255f, 111f / 255f);
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
    }

    public void StopTimer()
    {
        progress = false;
        attack = true;
        PlayGamesManager.Instance.SaveData();
    }

    public void StartTimer()
    {
        mission = false;
        progress = true;
        PlayGamesManager.Instance.SaveData();
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
