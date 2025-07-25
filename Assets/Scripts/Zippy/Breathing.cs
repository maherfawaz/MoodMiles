using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Breathing : MonoBehaviour
{
    
    public static float breathTimer = 180;
    public float holding = 5;
    public float breathSpeed = 4;
    public bool breathIn = true;
    public bool Hold = false;
    public bool breathOut = false;
    public TextMeshProUGUI counterTMP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        breathIn = true;
    }

    // Update is called once per frame
    public void Update()
    {
        breathTimer -= Time.deltaTime;

        if(breathTimer > 0)
        {
            if(breathIn == true)
            {
                counterTMP.text = "Breath!";
                gameObject.GetComponent<Slider>().value += breathSpeed;
                if(gameObject.GetComponent<Slider>().value == gameObject.GetComponent<Slider>().maxValue)
                {
                    breathIn = false;
                    Hold = true;
                }
            }

            if (Hold == true && gameObject.GetComponent<Slider>().value == gameObject.GetComponent<Slider>().maxValue)
            {
                counterTMP.text = "Hold!";
                holding -= Time.deltaTime;
                if(holding <= 0)
                {
                    Hold = false;
                    holding = 5;
                    breathOut = true;
                }
            }

            if (Hold == true && gameObject.GetComponent<Slider>().value == gameObject.GetComponent<Slider>().minValue)
            {
                counterTMP.text = "Hold!";
                holding -= Time.deltaTime;
                if (holding <= 0)
                {
                    Hold = false;
                    holding = 5;
                    breathIn = true;
                }
            }

            if (breathOut == true)
            {
                counterTMP.text = "Exhale!";
                gameObject.GetComponent<Slider>().value -= breathSpeed;
                if (gameObject.GetComponent<Slider>().value == gameObject.GetComponent<Slider>().minValue)
                {
                    breathOut = false;
                    Hold = true;
                }
            }
        }
        else
        {
            Zippy.attack = true;
            Zippy.progress = false;
            PlayGamesManager.Instance.SaveData();
            SceneManager.LoadScene("Zippy Home");
        }
        
    }
}
