using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public void End()
    {
        if (StaticHp.totalHP == 0)
        {
            SceneManager.LoadScene("Jail Cutsceen");
        }
        else
        {
            SnoozeInro.attack = false;
            SnoozeInro.finish = true;
            SceneManager.LoadScene(18);
        }
    }
}
