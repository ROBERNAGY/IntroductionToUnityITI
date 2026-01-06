using UnityEngine;
using UnityEngine.UIElements;

public class MovementHandlerCharacterController : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float runSpeed = 15.0f;
    [SerializeField] private float walkSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void HandlingMovement(Vector2 direction, bool isSprinting)
    {
        Move(direction, isSprinting);
        Rotate(direction);
    }

    void Move(Vector2 direction, bool isSprinting)
    {
        float speed = isSprinting ? runSpeed : walkSpeed;
        Vector3 move = new Vector3(direction.x * speed,0, direction.y * speed);

        characterController.Move(move);
    }
    void Rotate(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            Vector3 lookDir = new Vector3(direction.x, 0, direction.y);
            Quaternion targetRotation = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
