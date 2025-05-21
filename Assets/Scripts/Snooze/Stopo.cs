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
        main.GetComponent<Camera>().backgroundColor = Color.cyan;
        SnoozeInro.progress = false;
        SnoozeInro.attack = true;
    }
}
