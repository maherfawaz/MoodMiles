using UnityEngine;

public class Stopo : MonoBehaviour
{
    public GameObject main;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stoping()
    {
        main.GetComponent<Camera>().backgroundColor = new Color(178f / 255f, 208f / 255f, 255f / 255f);
        Snooze.progress = false;
        Snooze.attack = true;
        if (PlayGamesManager.Instance != null) {
            PlayGamesManager.Instance.SaveData();
        }
    }
}
