using UnityEngine;

public class DashHome : MonoBehaviour
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

        if (Dashie.mission == true)
        {
            mis.SetActive(true);
            prog.SetActive(false);
        }
        if (Dashie.progress == true)
        {
            mis.SetActive(false);
            prog.SetActive(true);
        }
    }
}
