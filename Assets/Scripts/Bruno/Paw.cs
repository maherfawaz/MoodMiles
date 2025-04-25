using UnityEngine;

public class Paw : MonoBehaviour
{
    public float QuickTime;
    public GameObject goodJob;
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
            StaticHp.totalHP -= 1;
            GameObject.FindWithTag("Manager").GetComponent<BearManager>().finish = true;
            goodJob.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
