using UnityEngine;

[RequireComponent(typeof(NewStepCounter))]
[RequireComponent(typeof(Calories))]
[RequireComponent(typeof(Sleep))]
public class MissionManager : MonoBehaviour
{
    void Start() {
        MissionManager[] objs = FindObjectsByType<MissionManager>(FindObjectsSortMode.None);
        if (objs.Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
