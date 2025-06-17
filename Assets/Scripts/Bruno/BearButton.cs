using UnityEngine;
using UnityEngine.SceneManagement;
public class BearButton : MonoBehaviour
{
    
    public GameObject progress;
    public int sNumber;
    public GameObject Light;
    public void Dashin()
    {
        if (Bruno.finish)
        {
            return;
        }
        
        if (Bruno.intro == false)
        {
            SceneManager.LoadScene("Bruno Intro");
        }

        else
        {
            SceneManager.LoadScene(sNumber);
        }
    }

    public void Update()
    {
        if (Bruno.intro == false || Bruno.mission == true)
        {
            Light.SetActive(true);
            progress.SetActive(false);
        }
        else if(Bruno.progress == true || Bruno.attack == true)
        {
            Light.SetActive(false);
            progress.SetActive(true);
        }
        else
        {
            Light.SetActive(false);
            progress.SetActive(false);
        }
    }
}
