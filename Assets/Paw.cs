using UnityEngine;

public class Paw : MonoBehaviour
{
    public float QuickTime;
    public float ptime;
    public float attacks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        QuickTime -= Time.deltaTime;
        if (QuickTime <= 0)
        {
            QuickTime = ptime;
            attacks = 0;
        }
        if(attacks == 10)
        {
            GameObject.FindWithTag("Health").GetComponent<Bosshealth>().health -= 1;
            gameObject.SetActive(false);
        }
    }
}
