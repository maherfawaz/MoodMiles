using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class BirdManager : MonoBehaviour
{
    private Camera _maindCamera;
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndtTouch(Vector2 position, float time);
    public event StartTouchEvent OnEndTouch;
    private InputSystem_Actions acting;
    public bool finish = false;
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
        if (OnStartTouch != null) OnStartTouch(acting.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
        if (finish == true)
        {
           
                Zippy.attack = false;
                Zippy.finish = true;
                PlayGamesManager.Instance.SaveData();
                SceneManager.LoadScene(18);
            

            
        }
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
