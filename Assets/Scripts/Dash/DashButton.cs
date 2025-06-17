using UnityEngine;
using UnityEngine.SceneManagement;

public class DashButton : MonoBehaviour
{
    
    public GameObject progr;
    public int sNumber;
    public GameObject Light;
    public void Dashin()
    {
        if (Dashie.finish)
        {
            return;
        }
        
        if (Dashie.intro == false)
        {
            SceneManager.LoadScene("Dash Intro");
        }

        else
        {
            SceneManager.LoadScene(sNumber);
        }
    }

    public void Update()
    {
        if (Dashie.intro == false || Dashie.mission == true)
        {
            Light.SetActive(true);
            progr.SetActive(false);
        }
        else if (Dashie.progress == true || Dashie.attack == true)
        {
            Light.SetActive(false);
            progr.SetActive(true);
        }
        else
        {
            Light.SetActive(false);
            progr.SetActive(false);
        }
    }
}
