using UnityEngine;
using UnityEngine.SceneManagement;

public class Zippy : MonoBehaviour
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
    public GameObject hatPrice;

    void Update()
    {
        if (Hat.ZhatsOn == true)
        {
            hat.SetActive(true);
        }
        if (Hat.ZhatsOn == false)
        {
            hat.SetActive(false);
        }
        if (attack == true || progress == true)
        {
            mis.SetActive(false);
            prog.SetActive(true);
            if (attack == true)
            {
                ready.SetActive(true);
                talkP.SetActive(false);
                talkF.SetActive(true);
            }
            else if (progress == true)
            {
                ready.SetActive(false);
                talkM.SetActive(false);
                talkF.SetActive(false);
                talkP.SetActive(true);
            }
        }
        else if (mission == true)
        {
            mis.SetActive(true);
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

    public void Zipp()
    {
        if (mission == true)
        {
            missionObj.SetActive(true);
        }

        if (attack == true)
        {
            if(skipTu == false)
            {
                tu.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("Quaid Bird Attack");
            }
        }
    }

    public void Next()
    {
        mission = false;
        progress = true;
    }
}
