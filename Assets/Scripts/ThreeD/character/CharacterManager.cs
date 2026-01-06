using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private InputHandler inputHandler;
    private MovementHandler movementHandler;
    private AnimatorHandler animatorHandler;
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        movementHandler = GetComponent<MovementHandler>();
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
