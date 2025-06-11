using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public GameObject check;

    public void Check() {
        if (check.activeSelf == false) {
            check.SetActive(true);
            if (SceneManager.GetActiveScene().name == "Zippy Home") {
                Zippy.skipTu = true;
            } else if (SceneManager.GetActiveScene().name == "Snooze Home") {
                Snooze.skipTu = true;
            } else if (SceneManager.GetActiveScene().name == "Bruno Home") {
                Bruno.skipTu = true;
            } else if (SceneManager.GetActiveScene().name == "Dash Home") {
                Dashie.skipTu = true;
            }
            PlayGamesManager.Instance.SaveData();
        } else {
            check.SetActive(false);
            if (SceneManager.GetActiveScene().name == "Zippy Home") {
                Zippy.skipTu = false;
            } else if (SceneManager.GetActiveScene().name == "Snooze Home") {
                Snooze.skipTu = false;
            } else if (SceneManager.GetActiveScene().name == "Bruno Home") {
                Bruno.skipTu = false;
            } else if (SceneManager.GetActiveScene().name == "Dash Home") {
                Dashie.skipTu = false;
            }
            PlayGamesManager.Instance.SaveData();
        }
    }
}
