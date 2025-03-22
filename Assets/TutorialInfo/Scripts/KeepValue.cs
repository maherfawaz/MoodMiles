using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class KeepValue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI maiText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        string newtext = Bosshealth.bu;
        maiText.text = newtext;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
