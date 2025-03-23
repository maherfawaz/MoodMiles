using UnityEngine;
using UnityEngine.SceneManagement;
public class SnoozeButton : MonoBehaviour
{
    public void Snooze()
    {
        if (SnoozeInro.intro == false)
        {
            SceneManager.LoadScene("Snooze Intro");
        }
    }
}
