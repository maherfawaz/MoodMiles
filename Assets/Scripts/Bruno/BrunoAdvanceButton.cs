using UnityEngine;
using UnityEngine.SceneManagement;
public class BrunoAdvanceButton : MonoBehaviour
{
    public GameObject mission;
    public GameObject tu;
    public GameObject ready;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Bruno.mission == true)
        {
            ready.SetActive(false);
        }
        if (Bruno.attack == true)
        {
            ready.SetActive(true);
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
            if (Zippy.skipTu == false)
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
