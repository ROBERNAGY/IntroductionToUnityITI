using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private Vector2 lastInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }
    private void ReadInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Debug.Log(horizontalInput +"  " + verticalInput);
    }
}
