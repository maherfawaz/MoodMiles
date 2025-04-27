using UnityEngine;
using UnityEngine.SceneManagement;
public class BearButton : MonoBehaviour
{
    public GameObject Dash;
    public GameObject progr;
    public GameObject Hound;
    public void Dashin()
    {
        if (Bruno.intro == false)
        {
            SceneManager.LoadScene("Bruno Intro");
        }

        if (Bruno.mission == true)
        {
            Dash.SetActive(true);

        }

        if (Bruno.progress == true)
        {
            progr.SetActive(true);
        }

        if (Bruno.attack == true)
        {
            Hound.SetActive(true);
        }

        if (Bruno.finish == true)
        {
            gameObject.SetActive(false);
        }
    }

    public void Accept()
    {
        Dashie.mission = false;
    }
}
