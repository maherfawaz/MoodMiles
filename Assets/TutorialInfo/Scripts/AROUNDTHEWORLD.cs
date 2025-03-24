using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AROUNDTHEWORLD : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 40f;
    [SerializeField] private Transform rotateAround;
    public bool charge = false;
    public float charging = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        this.transform.Rotate( Vector3.forward, rotationSpeed * Time.deltaTime);
        this.transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        if(charge == true)
        {
            charging -= Time.deltaTime;
            if (charging <= 0)
            {
                charge = false;
                StaticHp.totalHP -= 1;
                GameObject.FindWithTag("Manager").GetComponent<SlothInput>().finish = true;
                SnoozeInro.attack = false;
                SnoozeInro.mission = true;
                gameObject.SetActive(false);
                
            }
        }
    }

   
}
//Some code from "How to Rotate GameObjects in Unity 2d" by Game Dev by Kaupenjoe