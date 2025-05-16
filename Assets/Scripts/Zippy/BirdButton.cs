using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdButton : MonoBehaviour
{
    public GameObject Dash;
    public GameObject Hound;
    public int sNumber;
    public void Dashin()
    {

        if (Zippy.intro == false)
        {
            SceneManager.LoadScene("Zippy Intro");
        }

        else
        {
            SceneManager.LoadScene(sNumber);
        }

        
    }

    
}
