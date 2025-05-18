using UnityEngine;
using UnityEngine.SceneManagement;
public class SnoozeButton : MonoBehaviour
{
    public GameObject Snooooo;
    public GameObject progr;
    public GameObject setup;
    public int sNumber;
    public GameObject Light;
    public void Snooze()
    {
        if (SnoozeInro.intro == false)
        {
            SceneManager.LoadScene("Snooze Intro");
        }

        else
        {
            SceneManager.LoadScene(sNumber);
        }
    }

    public void Update()
    {
        if (SnoozeInro.intro == false)
        {
            Light.SetActive(true);

        }

        else
        {
            Light.SetActive(false);
        }
    }
}
