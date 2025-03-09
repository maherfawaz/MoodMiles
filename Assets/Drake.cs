using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Drake : MonoBehaviour
{
    public int stepCount;
    public Text stepsText;

    void Start() {
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION")) {
            UnityEngine.Android.Permission.RequestUserPermission("android.permission.ACTIVITY_RECOGNITION");
        }
        InputSystem.GetDevice<StepCounter>();
        if (InputSystem.GetDevice<StepCounter>() != null) {
            InputSystem.EnableDevice(InputSystem.GetDevice<StepCounter>());
        }
        stepsText = GameObject.Find("Steps").GetComponent<Text>();
    }

    void Update() {
        if (InputSystem.GetDevice<StepCounter>() != null) {
            var value = StepCounter.current.stepCounter.ReadValue();
            stepCount = value;
            stepsText.text = $"Steps: {stepCount}";
        }
    }

    public void OnStep(InputAction.CallbackContext context) {
        Debug.Log("Step detected!");
    }
}
