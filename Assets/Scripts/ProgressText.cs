using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressText : MonoBehaviour
{
    public TextMeshProUGUI textUse;
    public TextMeshProUGUI textNeeded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textUse.text = textNeeded.text;
    }
}
