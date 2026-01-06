using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private MyInputActions myInputActions;
    private FPSCamera fPSCamera;
    private TPSCamera tPSCamera;
    void Awake()
    {
        myInputActions = new MyInputActions();
        fPSCamera = GetComponent<FPSCamera>();
        tPSCamera = GetComponent<TPSCamera>();
    }
    private void OnEnable()
    {
        myInputActions.Enable();
    }
    private void OnDisable()
    {
        myInputActions.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myInputActions.SchoolGirl.SwitchCamera.IsPressed())
        {
            SwitchCamera();
        }
    }
    void SwitchCamera()
    {
        fPSCamera.enabled = !fPSCamera.enabled;
        tPSCamera.enabled = !tPSCamera.enabled;
    }
}
