using UnityEngine;

public class StartTimer : MonoBehaviour
{
    public GameObject sleep;
    public GameObject main;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Timer()
    {
        main.GetComponent<Camera>().backgroundColor = Color.black;
        SnoozeInro.mission = false;
        SnoozeInro.progress = true;
        sleep.GetComponent<Sleep>().timerIsRunning = true;
    }
}
