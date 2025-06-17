using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdButton : MonoBehaviour
{
    
    public GameObject Light;
    public int sNumber;
    public void Dashin()
    {
        if (Zippy.finish)
        {
            return;
        }

        if (Zippy.intro == false)
        {
            SceneManager.LoadScene("Zippy Intro");
        }

        else
        {
            SceneManager.LoadScene(sNumber);
        }

        
    }

    public void Update()
    {
        if (Zippy.intro == false || Zippy.mission == true)
        {
            Light.SetActive(true);
        }

        else
        {
            Light.SetActive(false);
        }
    }
}
