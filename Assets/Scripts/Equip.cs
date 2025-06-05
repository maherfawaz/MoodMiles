using UnityEngine;

public class Equip : MonoBehaviour
{
    
    public int numberId;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Wears()
    {
        Hat.id = numberId;
        Hat.hatsOn = true;
    }
    public void BWears()
    {
        Hat.id = numberId;
        Hat.BhatsOn = true;
    }
    public void DWears()
    {
        Hat.id = numberId;
        Hat.DhatsOn = true;
    }
    public void ZWears()
    {
        Hat.id = numberId;
        Hat.ZhatsOn = true;
    }
}
