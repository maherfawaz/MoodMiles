using UnityEngine;

public class Skip : MonoBehaviour
{
    public GameObject check;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check()
    {
        check.SetActive(true);
        Zippy.skipTu = true;
        if (PlayGamesManager.Instance != null) {
            PlayGamesManager.Instance.SaveData();
        }
    }
}
