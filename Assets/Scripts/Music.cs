using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    void Start() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update() {
        if (SceneManager.GetActiveScene().name == "Jail Cutsceen") {
            Destroy(gameObject);
        }
    }
}
