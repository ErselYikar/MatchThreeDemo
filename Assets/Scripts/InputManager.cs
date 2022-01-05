using UnityEngine;
using UnityEngine.InputSystem;


[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    public delegate void StartTouch(Vector2 position, float time);
    public static event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public static event EndTouch OnEndTouch;

    public static InputManager Instance;


    private Swipe swipe;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        swipe = new Swipe();
    }

    private void OnEnable()
    {
        swipe.Enable();
    }

    private void OnDisable()
    {
        swipe.Disable();
    }

    private void Start()
    {
        swipe.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        swipe.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    public void StartTouchPrimary(InputAction.CallbackContext ctx)
    {
        if(OnStartTouch != null)
        {
            OnStartTouch(Utils.ScreenToWorld(Camera.main, swipe.Touch.PrimaryPos.ReadValue<Vector2>()),(float)ctx.startTime);
        }
    }

    public void EndTouchPrimary(InputAction.CallbackContext ctx)
    {
        if (OnEndTouch != null)
        {
            OnEndTouch(Utils.ScreenToWorld(Camera.main, swipe.Touch.PrimaryPos.ReadValue<Vector2>()), (float)ctx.time);
        }
    }

    public Vector2 PrimaryPos()
    {
        return Utils.ScreenToWorld(Camera.main, swipe.Touch.PrimaryPos.ReadValue<Vector2>());
    }
}
