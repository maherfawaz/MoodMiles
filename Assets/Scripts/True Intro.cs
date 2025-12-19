using UnityEngine;

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
    }

    public void InEnd()
    {
        trueIntro = false;
    }
}
