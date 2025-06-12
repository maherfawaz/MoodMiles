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
    }

    public void InEnd()
    {
        trueIntro = false;
        PlayGamesManager.Instance.SaveData();
    }
}
