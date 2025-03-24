using UnityEngine;
using UnityEngine.SceneManagement;
public class SnoozeButton : MonoBehaviour
{
    public GameObject Snooooo;
    public GameObject setup;
    public void Snooze()
    {
        if (SnoozeInro.intro == false)
        {
            SceneManager.LoadScene("Snooze Intro");
        }

        if (SnoozeInro.mission == true)
        {
            Snooooo.SetActive(true);
        }

        if (SnoozeInro.attack == true)
        {
            setup.SetActive(true);
        }
    }
}
