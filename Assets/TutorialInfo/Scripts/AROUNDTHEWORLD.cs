using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AROUNDTHEWORLD : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 40f;
    [SerializeField] private Transform rotateAround;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate( Vector3.forward, rotationSpeed * Time.deltaTime);
        this.transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
//Some code from "How to Rotate GameObjects in Unity 2d" by Game Dev by Kaupenjoe