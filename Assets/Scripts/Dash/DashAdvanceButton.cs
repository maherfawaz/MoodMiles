using UnityEngine;
using UnityEngine.SceneManagement;

public class DashAdvanceButton : MonoBehaviour
{
    public GameObject mission;
    public GameObject tu;
    public GameObject ready;
    public GameObject talkM;
    public GameObject talkP;
    public GameObject talkF;
    public GameObject hat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
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
        if (Dashie.mission == true)
        {
            ready.SetActive(false);
            talkM.SetActive(true);
            talkF.SetActive(false);
        }
        if (Dashie.progress == true)
        {
            ready.SetActive(false);
            talkM.SetActive(false);
            talkP.SetActive(true);
        }
        if (Dashie.attack == true)
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
        if (Dashie.mission == true)
        {
            mission.SetActive(true);
        }

        if (Dashie.attack == true)
        {
            if (Zippy.skipTu == false)
            {
                tu.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("Quaid Dog Attack");
            }
        }
        else
        {
           
        }
    }
}
