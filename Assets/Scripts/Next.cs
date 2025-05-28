using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public void End()
    {
        
        
            SnoozeInro.attack = false;
            SnoozeInro.finish = true;
            SceneManager.LoadScene(18);
        
    }
}
