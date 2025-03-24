using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void Finisher()
    {
        StaticHp.totalHP = 1;
        SceneManager.LoadScene("Quaid Base");
    }
}
