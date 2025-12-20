using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueIntro : MonoBehaviour
{
    public static bool trueIntro = true;
    public GameObject intro;

    void Start()
    {
        if (trueIntro == true)
        {
            intro.SetActive(true);
        }
        if (GameObject.Find("Music").GetComponent<AudioSource>().isPlaying == false)
        {
            GameObject.Find("Music").GetComponent<AudioSource>().UnPause();
        }
        if (StaticHp.totalHP <= 0)
        {
            SceneManager.LoadScene("Congratulations");
        }
    }

    public void InEnd()
    {
        trueIntro = false;
    }
}
