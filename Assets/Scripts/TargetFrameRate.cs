using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    void Start() {
        //RefreshRate refreshRate = Screen.currentResolution.refreshRateRatio;
        //Application.targetFrameRate = (int)refreshRate.numerator;
        Application.targetFrameRate = 200;
    }
}
