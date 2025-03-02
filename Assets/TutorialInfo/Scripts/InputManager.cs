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
        acting.UI.Click.started += ctx => StartTouch(ctx);
        acting.UI.Click.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {

    }
    private void EndTouch(InputAction.CallbackContext context)
    {

    }
}
