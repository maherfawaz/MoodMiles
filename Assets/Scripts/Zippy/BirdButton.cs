using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdButton : MonoBehaviour
{
    public GameObject Dash;
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

        if (Zippy.attack == true)
        {
            Hound.SetActive(true);
        }

        if (Zippy.finish == true)
        {
            gameObject.SetActive(false);
        }
    }

    public void Accept()
    {
        Dashie.mission = false;
    }
}
