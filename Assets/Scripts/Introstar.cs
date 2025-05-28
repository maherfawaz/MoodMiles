using UnityEngine;

public class Introstar : MonoBehaviour
{
    public GameObject intro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TrueIntro.trueIntro == true)
        {
            intro.SetActive(true);
        }
    }

    public void InEnd()
    {
        TrueIntro.trueIntro = false;
        if (PlayGamesManager.Instance != null) {
            PlayGamesManager.Instance.SaveData();
        }
    }
}
