using UnityEngine;

// Currently used for MissionManager and Music objects, which appear in Quaid Base scene
public class DontDestroyOnLoad : MonoBehaviour
{
    [Header("Dynamic")]
    public string objectTag;

    void Start() {
        objectTag = gameObject.tag;
        GameObject[] objs = GameObject.FindGameObjectsWithTag(objectTag);

        if (objs.Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
