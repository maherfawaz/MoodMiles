using UnityEngine;

public class BrunoHome : MonoBehaviour
{
    public GameObject mis;
    public GameObject prog;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Bruno.progress == true)
        {
            mis.SetActive(false);
            prog.SetActive(true);
        }
        else if (Bruno.mission == true)
        {
            mis.SetActive(true);
            prog.SetActive(false);
        }
    }
}
