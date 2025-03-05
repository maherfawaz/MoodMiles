using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Testbut : MonoBehaviour
{
    public int sNumber;
    public void testButton()
    {
        SceneManager.LoadScene(sNumber);

    }
}
