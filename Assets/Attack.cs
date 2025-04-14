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

    public void BearAttack()
    {
        SceneManager.LoadScene("Quaid Bear Attack");
    }

    public void BirdAttack()
    {
        SceneManager.LoadScene("Quaid Bird Attack");
    }
}
