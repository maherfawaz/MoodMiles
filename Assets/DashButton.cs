using UnityEngine;
using UnityEngine.SceneManagement;

public class DashButton : MonoBehaviour
{
    public GameObject Dash;
    public GameObject Hound;
    public GameObject progr;
    public void Dashin()
    {
        if (Dashie.intro == false)
        {
            SceneManager.LoadScene("Dash Intro");
        }

        if (Dashie.mission == true)
        {
            Dash.SetActive(true);
            
        }

        if (Dashie.progress == true)
        {
            progr.SetActive(true);
        }

        if (Dashie.attack == true)
        {
            Hound.SetActive(true);
        }
    }

    public void Accept()
    {
        Dashie.mission = false;
    }
}
