using UnityEngine;

public class Sno : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        Snooze.mission = false;
        Snooze.progress = true;
    }
}
