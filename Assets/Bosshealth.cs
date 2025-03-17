using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Bosshealth : MonoBehaviour
{
    public int health = 8;
    public TextMeshProUGUI mainText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mainText.text = health.ToString();
    }
}
