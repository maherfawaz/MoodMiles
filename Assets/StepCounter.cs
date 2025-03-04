using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class StepCounter : Sensor
{    
    [Header("Dynamic")]
    public int steps;
    public static StepCounter current { get; private set; }
    public IntegerControl stepCounter { get; protected set; }
    public InputAction stepCount;

    public void Start() {
        var device = InputSystem.GetDevice<StepCounter>();
        if (device != null) {
            stepCounter = device.stepCounter;
            InputSystem.EnableDevice(device);
            current = this;
        }
    }

    public void Update() {
        if (StepCounter.current != null) {
            steps = StepCounter.current.stepCounter.ReadValue();
        }
        //GetSensorValue();
    }

    /*public void OnStep(InputAction.CallbackContext context) {
        steps++;
    }*/

    public string GetSensorName() {
        return "StepCounter";
    }

    public string GetSensorValue() {
        return steps.ToString();
    }
}
