using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class DahTalk : MonoBehaviour
{
    public TextMeshProUGUI textUse;
    public string[] lines;
    public float textSpeed;
    private int index;


    // Start is called before the first frame update
    void Start()
    {
        textUse.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    public void Go()
    {


        if (textUse.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textUse.text = lines[index];
        }

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textUse.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textUse.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Dashie.intro = true;
            Dashie.mission = true;
            SceneManager.LoadScene("Quaid Base");

        }
    }
}

//Helped by "5 Minute DIALOGUE SYSTEM in UNITY Tutorial" by BMo