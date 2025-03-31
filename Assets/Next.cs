using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public void End()
    {
        if (GameObject.FindWithTag("Manager").GetComponent<SlothInput>().finish == true)
        {
            if (StaticHp.totalHP == 0)
            {
                SceneManager.LoadScene("Jail Cutsceen");
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
