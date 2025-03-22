using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Bosshealth : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI mainText;
    public static string bu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = StaticHp.totalHP;
        mainText.text = bu;
         bu = health.ToString();
        
    }
}
