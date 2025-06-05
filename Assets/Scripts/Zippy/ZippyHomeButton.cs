using UnityEngine;
using UnityEngine.SceneManagement;

public class ZippyHomeButton : MonoBehaviour
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
        if (Hat.ZhatsOn == true)
        {
            hat.SetActive(true);
        }
        if (Hat.ZhatsOn == false)
        {
            hat.SetActive(false);
        }
        if (Zippy.mission == true)
        {
            ready.SetActive(false);
            talkM.SetActive(true);
            talkF.SetActive(false);
        }
       
        if (Zippy.attack == true)
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
        if (Zippy.mission == true)
        {
            mission.SetActive(true);
        }

        if (Zippy.attack == true)
        {
            if(Zippy.skipTu == false)
            {
                tu.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("Quaid Bird Attack");
            }
        }
        else
        {

        }
    }
    
}
