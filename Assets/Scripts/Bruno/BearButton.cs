using UnityEngine;
using UnityEngine.SceneManagement;
public class BearButton : MonoBehaviour
{
    public GameObject Dash;
    public GameObject progr;
    public GameObject Hound;
    public int sNumber;
    public GameObject Light;
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

    public void Update()
    {
        if (Bruno.intro == false)
        {
            Light.SetActive(true);

        }

        else
        {
            Light.SetActive(false);
        }
    }
}
