using UnityEngine;
using UnityEngine.SceneManagement;

public class DashButton : MonoBehaviour
{
    public GameObject Dash;
    public GameObject Hound;
    public GameObject progr;
    public int sNumber;
    public void Dashin()
    {
        if (Dashie.intro == false)
        {
            SceneManager.LoadScene("Dash Intro");
        }

        else
        {
            SceneManager.LoadScene(sNumber);
        }
    }

    
}
