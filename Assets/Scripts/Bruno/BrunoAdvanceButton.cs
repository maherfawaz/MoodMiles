using UnityEngine;
using UnityEngine.SceneManagement;
public class BrunoAdvanceButton : MonoBehaviour
{
    public GameObject mission;
    public GameObject tu;
    public GameObject hat;
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
        if (Hat.BhatsOn == true)
        {
            hat.SetActive(true);
        }
        if (Hat.BhatsOn == false)
        {
            hat.SetActive(false);
        }
        if (Bruno.attack == true)
        {
            ready.SetActive(true);
            talkP.SetActive(false);
            talkF.SetActive(true);
        }
        else if (Bruno.progress == true)
        {
            ready.SetActive(false);
            talkM.SetActive(false);
            talkP.SetActive(true);
           
        }
        else if (Bruno.mission == true)
        {
            ready.SetActive(false);
            talkM.SetActive(true);
            talkF.SetActive(false);
           
        }
        else
        {
            ready.SetActive(false);
        }
    }

    public void Zipp()
    {
        if (Bruno.mission == true)
        {
            mission.SetActive(true);
        }

        if (Bruno.attack == true)
        {
            if (Bruno.skipTu == false)
            {
                tu.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("Quaid Bear Attack");
            }
        }
        else
        {

        }
    }
}
