using UnityEngine;

// https://discussions.unity.com/t/simple-timer/56201/3
public class Sleep : MonoBehaviour
{
    [Header("Inscribed")]
    public int hours;

    public void StartSleepTimer() {
        Invoke("WakeUp", hours * 3600);
    }

    public void WakeUp() {
        Debug.Log("Wake up!");
    }
}
