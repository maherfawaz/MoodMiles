using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]

public class dogManager : MonoBehaviour
{
    public bool activate;
    public GameObject wellDone;
    private Camera _maindCamera;
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndtTouch(Vector2 position, float time);
    public event StartTouchEvent OnEndTouch;
    private InputSystem_Actions acting;
    public float ShakeForceMultiplier;
    public Rigidbody2D[] ShakingRigidbodies;
    public GameObject Shaker;
    public GameObject progress;
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
        if(finish == true)
        {
            StaticHp.totalHP -= 1;
            if (StaticHp.totalHP > 0)
            {
                Dashie.attack = false;
                Dashie.finish = true;
                SceneManager.LoadScene(2);
            }
            
            if (StaticHp.totalHP == 0)
            {
                SceneManager.LoadScene("Jail Cutsceen");
            }
            
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

    public void ShakeRigidbodies(Vector3 deviceAcceleration)
    {
        foreach (var rigidbody in ShakingRigidbodies)
        {
            //rigidbody.AddForce(deviceAcceleration * ShakeForceMultiplier, ForceMode2D.Impulse);
            activate = true;
            
        }
    }

    public void Update()
    {
        if(activate == true)
        {
            progress.GetComponent<Charge>().current += 0.1f;
        }

        if(finish == true)
        {
            Shaker.SetActive(false);
            wellDone.SetActive(true);
        }
    }

}
