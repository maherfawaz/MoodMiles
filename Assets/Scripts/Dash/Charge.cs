using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Charge : MonoBehaviour
{
    public int maximum;
    public float current;
    public Image mask;
    public bool hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Update()
    {
        GetCurrentFill();

        if (current >= maximum)
        {


            GameObject.FindWithTag("Manager").GetComponent<dogManager>().finish = true;

        }
    }


    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
        

    }
}
