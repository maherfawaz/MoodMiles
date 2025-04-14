using UnityEngine;
using UnityEngine.SceneManagement;
public class BearButton : MonoBehaviour
{
    public GameObject Dash;
    public GameObject Hound;
    public void Dashin()
    {
        if (Dashie.intro == false)
        {
            SceneManager.LoadScene("Bruno Intro");
        }

        if (Dashie.mission == true)
        {
            Dash.SetActive(true);

        }

        if (Dashie.attack == true)
        {
            Hound.SetActive(true);
        }
    }

    public void Accept()
    {
        Dashie.mission = false;
    }
}
