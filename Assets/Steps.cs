using UnityEngine;

public class Steps : MonoBehaviour
{
    public StepCounter stepCounter;
    public int steps;

    private float updateInterval = 1.0f; // Update every 1 second
    private float nextUpdateTime = 0.0f;

    void Start() {
        stepCounter = StepCounter.current;
        stepCounter.Start();
    }

    void Update() {
        if (Time.time >= nextUpdateTime) {
            stepCounter.Update();
            steps = stepCounter.steps;
            nextUpdateTime = Time.time + updateInterval;
        }
    }
}
