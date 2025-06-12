using UnityEngine;

public class SnoozeHome : MonoBehaviour
{
    public GameObject mis;
    public GameObject prog;
    public GameObject count;
    public GameObject main;
    public GameObject hat;

    // Update is called once per frame
    void Update()
    {
        if (Hat.hatsOn == true)
        {
            hat.SetActive(true);
        }
        else if (Hat.hatsOn == false)
        {
            hat.SetActive(false);
        }
        if (Snooze.progress == true)
        {
            mis.SetActive(false);
            prog.SetActive(true);
            count.SetActive(true);
            main.GetComponent<Camera>().backgroundColor = new Color(76f / 255f, 176f / 255f, 229f / 255f);
        }
        else if (Snooze.mission == true)
        {
            mis.SetActive(true);
            prog.SetActive(false);
            count.SetActive(false);
            main.GetComponent<Camera>().backgroundColor = new Color(178f / 255f, 208f / 255f, 255f / 255f);
        }
        else
        {
            main.GetComponent<Camera>().backgroundColor = new Color(178f / 255f, 208f / 255f, 255f / 255f);
        }
    }

    public void StopTimer()
    {
        Snooze.progress = false;
        Snooze.attack = true;
        PlayGamesManager.Instance.SaveData();
    }

    public void StartTimer()
    {
        Snooze.mission = false;
        Snooze.progress = true;
        PlayGamesManager.Instance.SaveData();
    }
}
