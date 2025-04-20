using UnityEngine;

public class MissonStart : MonoBehaviour
{
    public string animalName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Missi()
    {
        if(animalName == "Bruno")
        {
            Bruno.mission = false;
            Bruno.progress = true;
        }
        if (animalName == "Zippy")
        {
            Zippy.mission = false;
            Zippy.progress = true;
        }
        if (animalName == "Snooze")
        {
            SnoozeInro.mission = false;
            SnoozeInro.progress = true;
        }
        if (animalName == "Dash")
        {
            Dashie.mission = false;
            Dashie.progress = true;
        }
    }
    
}
