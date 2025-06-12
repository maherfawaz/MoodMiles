using UnityEngine;
using UnityEngine.UI;

public class StaticHp : MonoBehaviour
{
    public static int totalHP = 4;
    public int maximum;
    public Image mask;

    void Update()
    {
        float fillAmount = (float)totalHP / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
