using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour
{
    public TextMeshProUGUI textUse;
    public string[] lines;
    public float textSpeed;
    public string animalName;
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
        else if (animalName == "Snooze")
        {
            SnoozeInro.intro = true;
            SnoozeInro.mission = true;
            SceneManager.LoadScene("Snooze Home");
        }
        else if (animalName == "Dash")
        {
            Dashie.intro = true;
            Dashie.mission = true;
            SceneManager.LoadScene("Dash Home");
        }
        else if (animalName == "Zippy")
        {
            Zippy.intro = true;
            Zippy.mission = true;
            SceneManager.LoadScene("Zippy Home");
        }

        else if (animalName == "Bruno")
        {
            Bruno.intro = true;
            Bruno.mission = true;
            SceneManager.LoadScene("Bruno Home");
        }
    }
}

//Helped by "5 Minute DIALOGUE SYSTEM in UNITY Tutorial" by BMo