using UnityEngine;

public class ScaleFromMicrophone : MonoBehaviour
{
    
    public Vector3 minScale, maxScale;
    public AudioLoudnessDetector detector;

    public float loudnessSensibility = 100f;
    public float threshold = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        //float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensibility;
        //Debug.Log(loudness);
       // if (loudness < threshold) loudness = 0;

        //transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
