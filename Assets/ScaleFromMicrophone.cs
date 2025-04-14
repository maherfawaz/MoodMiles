using UnityEngine;

public class ScaleFromMicrophone : MonoBehaviour
{
    
    public Vector3 minScale, maxScale;
    public AudioLoudnessDetector detector;
    public GameObject goodJob;
    public float loudnessSensibility = 100f;
    public float threshold = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        Debug.Log(loudness);
        if (loudness < threshold) loudness = 0;

        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);

        if (gameObject.transform.localScale == maxScale)
        {
            GameObject.FindWithTag("Manager").GetComponent<BirdManager>().finish = true;
            goodJob.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
