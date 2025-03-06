using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    private Camera _maindCamera;
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndtTouch(Vector2 position, float time);
    public event StartTouchEvent OnEndTouch; 
    private InputSystem_Actions acting;

    private void Awake()
    {
        acting = new InputSystem_Actions();
        _maindCamera = Camera.main;
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
        acting.Touch.TouchPress.started += ctx => StartTouch(ctx);
        acting.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch started " + acting.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null) OnStartTouch(acting.Touch.TouchPosition.ReadValue<Vector2>(), (float) context.startTime);
    }
    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch ended " + acting.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null) OnStartTouch(acting.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_maindCamera.ScreenPointToRay(Touchscreen.current.position.ReadValue()));
        if (!rayHit.collider) return;

        Debug.Log(rayHit.collider.gameObject.name);
    }
}
//"How to use Touch with NEW Input System - Unity Tutorial" by Samyam
//Some code from "Detect Clicks in Unity 2D (New Input System) | Bite-Sized Tutorials" by chonk