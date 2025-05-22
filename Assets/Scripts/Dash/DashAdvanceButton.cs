using UnityEngine;
using UnityEngine.SceneManagement;

public class DashAdvanceButton : MonoBehaviour
{
    public GameObject mission;
    public GameObject tu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Dashie.mission == true)
        {

        }
        if (Dashie.attack == true)
        {

        }
        else
        {

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
