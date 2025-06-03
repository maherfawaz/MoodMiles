using UnityEngine;

public class SnoozeHome : MonoBehaviour
{
    public GameObject mis;
    public GameObject prog;
    public GameObject count;
    public GameObject main;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Snooze.mission == true)
        {
            mis.SetActive(true);
            prog.SetActive(false);
            count.SetActive(false);
            main.GetComponent<Camera>().backgroundColor = Color.cyan;
        }
        if (Snooze.progress == true)
        {
            mis.SetActive(false);
            prog.SetActive(true);
            count.SetActive(true);
            main.GetComponent<Camera>().backgroundColor = Color.black;
        }
        else
        {
            main.GetComponent<Camera>().backgroundColor = Color.cyan;
        }
    }
}
