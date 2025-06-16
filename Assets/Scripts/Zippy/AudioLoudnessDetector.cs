using UnityEngine;

public class AudioLoudnessDetector : MonoBehaviour
{
    public int sampleWindow = 64;
    private string _microphoneName;
    private AudioClip _microphoneClip;

    private void Start()
    {
        RequestPermission();
    }

    private void MicrophoneToAudioClip(int microphoneIndex)
    {

        _microphoneName = Microphone.devices[microphoneIndex];
        _microphoneClip = Microphone.Start(_microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(_microphoneName), _microphoneClip);
    }

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
    
    async void RequestPermission()
    {
#if UNITY_EDITOR
        Debug.Log("Editor Platform");
        MicrophoneToAudioClip(microphoneIndex: 0);
#endif
#if UNITY_ANDROID
        AndroidRuntimePermissions.Permission result = await AndroidRuntimePermissions.RequestPermissionAsync("android.permission.RECORD_AUDIO");
        if (result == AndroidRuntimePermissions.Permission.Granted)
        {
            Debug.Log("Permission granted");
            MicrophoneToAudioClip(microphoneIndex: 0);
        }
        else
        {
            Debug.Log("Permission denied");
        }
#endif
    }
}
