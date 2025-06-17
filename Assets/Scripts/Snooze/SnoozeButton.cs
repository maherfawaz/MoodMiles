using UnityEngine;
using UnityEngine.SceneManagement;
public class SnoozeButton : MonoBehaviour
{
    
    public GameObject progr;
   
    public int sNumber;
    public GameObject Light;
    public void Snooze()
    {
        if (global::Snooze.finish)
        {
            return;
        }
        
        if (global::Snooze.intro == false)
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
        if (global::Snooze.intro == false)
        {
            Light.SetActive(true);
            progr.SetActive(false);
        }
        else if (global::Snooze.progress == true || global::Snooze.attack == true)
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
