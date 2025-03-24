using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void Finisher()
    {
        StaticHp.totalHP = 8;
        SceneManager.LoadScene("Quaid Base");
    }
}
