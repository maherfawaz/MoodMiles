using UnityEngine;
using UnityEngine.SceneManagement;
public class BearButton : MonoBehaviour
{
    public GameObject Dash;
    public GameObject progr;
    public GameObject Hound;
    public int sNumber;
    public void Dashin()
    {
        if (Bruno.intro == false)
        {
            SceneManager.LoadScene("Bruno Intro");
        }

        else
        {
            SceneManager.LoadScene(sNumber);
        }
    }

  
}
