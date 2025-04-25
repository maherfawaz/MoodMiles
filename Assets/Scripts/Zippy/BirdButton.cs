using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdButton : MonoBehaviour
{
    public GameObject Dash;
    public GameObject progr;
    public GameObject Hound;
    public void Dashin()
    {
        if (Zippy.intro == false)
        {
            SceneManager.LoadScene("Zippy Intro");
        }

        if (Zippy.mission == true)
        {
            Dash.SetActive(true);

        }

        if(Zippy.progress == true)
        {
            progr.SetActive(true);
        }

        if (Zippy.attack == true)
        {
            Hound.SetActive(true);
        }
    }

    public void Accept()
    {
        Dashie.mission = false;
    }
}
