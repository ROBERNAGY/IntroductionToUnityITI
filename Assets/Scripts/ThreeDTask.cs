using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ThreeDTask : MonoBehaviour
{
    private float x;
    private float z;
    CharacterController characterController;
    private float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        x =Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

    }
}
