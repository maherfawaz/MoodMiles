using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetector : MonoBehaviour
{
    public int sampleWindow = 64;

    private AudioClip _microphoneClip;

    private void Start()
    {
        {
            MicrophoneToAudioClip(microphoneIndex: 0);
        }
    }
    private void MicrophoneToAudioClip(int microphoneIndex)
    {
        foreach (var name in Microphone.devices)
        {
            Debug.Log(name);
        }
    }
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
