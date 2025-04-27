using UnityEngine;
using UnityEngine.UI;
public class DashProgress : MonoBehaviour
{
    public float maximum;
    public float current;
    public Image mask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        GetCurrentFill();
        current = NewStepCounter.st;
        maximum = NewStepCounter.sg;

    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;

    }
}
