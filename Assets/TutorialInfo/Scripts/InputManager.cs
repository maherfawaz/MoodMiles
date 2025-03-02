using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions acting;

    private void Awake()
    {
        acting = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        acting.Enable();
    }

    private void OnDisable()
    {
        acting.Disable();
    }

    private void Start()
    {
        acting.Player.Attack.started += ctx => StartTouch(ctx);
        acting.Player.Attack.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch start");
    }
    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch end");
    }
}
