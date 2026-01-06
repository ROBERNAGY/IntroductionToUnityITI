using UnityEngine;

public class CharacterManagerCharacterController : MonoBehaviour
{
    private InputHandler inputHandler;
    private MovementHandlerCharacterController movementHandler;
    private AnimatorHandler animatorHandler;
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        movementHandler = GetComponent<MovementHandlerCharacterController>();
        animatorHandler = GetComponent<AnimatorHandler>();
    }

    void Update()
    {
        inputHandler.ReadInput();
        Vector2 direction = inputHandler.direction;
        bool isSprinting = inputHandler.isSprinting;
        movementHandler.HandlingMovement(direction, isSprinting);
        animatorHandler.UpdateAnimatorValues(direction , isSprinting);
    }
}
