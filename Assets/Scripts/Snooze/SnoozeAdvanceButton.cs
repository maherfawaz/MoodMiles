using UnityEngine;
using UnityEngine.SceneManagement;
public class SnoozeAdvanceButton : MonoBehaviour
{
    public GameObject mission;
    public GameObject tu;
    public GameObject ready;
    public GameObject talkM;
    public GameObject talkP;
    public GameObject talkF;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Snooze.mission == true)
        {
            ready.SetActive(false);
            talkM.SetActive(true);
            talkF.SetActive(false);
        }
        if (Snooze.progress == true)
        {
            ready.SetActive(false);
            talkM.SetActive(false);
            talkP.SetActive(true);
        }
        if (Snooze.attack == true)
        {
            ready.SetActive(true);
            talkP.SetActive(false);
            talkF.SetActive(true);
        }
        else
        {
            ready.SetActive(false);
        }
    }

    public void Zipp()
    {
        if (Snooze.mission == true)
        {
            mission.SetActive(true);
        }

        if (Snooze.attack == true)
        {
            if (Zippy.skipTu == false)
            {
                tu.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("Quaid Sloth Click");
            }
        }
        else
        {

        }
    }
}
