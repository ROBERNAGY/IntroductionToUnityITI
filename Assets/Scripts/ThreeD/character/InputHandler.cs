using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private MyInputActions myInputActions;
    public Vector2 direction
    {
        get;
        private set;
    }
    public bool isSprinting
    {
        get;
        private set;
    }
    void Awake()
    {
        myInputActions = new MyInputActions();
        
    }
    private void OnEnable()
    {
        myInputActions.Enable();
    }
    private void OnDisable()
    {
         myInputActions.Disable();
    }
    void Start()
    {
        
    }
    public void ReadInput()
    {
        direction = myInputActions.SchoolGirl.Move.ReadValue<Vector2>();
        isSprinting = myInputActions.SchoolGirl.Sprint.IsPressed();
    }
}
