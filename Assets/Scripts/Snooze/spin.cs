using UnityEngine;

public class spin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 40f;
    [SerializeField] private Transform rotateAround;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    }

