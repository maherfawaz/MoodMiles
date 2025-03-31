using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{
    public void SnoozeAttack()
    {
        SceneManager.LoadScene("Quaid Sloth Click");
    }

    public void DashAttack()
    {
        SceneManager.LoadScene("Quaid Dog Attack");
    }
}
