using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdButton : MonoBehaviour
{
    public GameObject Dash;
    public GameObject Hound;
    public GameObject Light;
    public int sNumber;
    public void Dashin()
    {

        if (Zippy.intro == false)
        {
            Light.SetActive(true);
            SceneManager.LoadScene("Zippy Intro");
        }

        else
        {
            SceneManager.LoadScene(sNumber);
        }

        
    }

    public void Update()
    {
        if (Zippy.intro == false)
        {
            Light.SetActive(true);
            
        }

        else
        {
            Light.SetActive(false);
        }
    }
}
