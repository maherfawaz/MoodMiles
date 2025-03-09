using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class StepCounter : Sensor
{
    public static StepCounter current { get; }
    public IntegerControl stepCounter { get; protected set; }
}
