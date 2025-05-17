using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    [Header("Dynamic")]
    public AudioSource musicSource;

    void Start() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
            musicSource = GetComponent<AudioSource>();
        }
    }

    void Update() {
        if (SceneManager.GetActiveScene().name == "Jail Cutsceen") {
            musicSource.Pause();
        } else if (musicSource.isPlaying == false) {
            musicSource.UnPause();
        }
    }
}
