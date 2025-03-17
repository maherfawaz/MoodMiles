using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetector : MonoBehaviour
{
    public int sampleWindow = 64;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0) return 0;

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float TOTALlOUDNESS = 0;

        foreach (var sample in waveData)
        {
            TOTALlOUDNESS += Mathf.Abs(sample);
        }
        return TOTALlOUDNESS / sampleWindow;
    }
}
