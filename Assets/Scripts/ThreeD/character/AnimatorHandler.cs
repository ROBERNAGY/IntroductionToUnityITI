using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    private Animator animator;
    private int speedHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        speedHash = Animator.StringToHash("Speed");
    }

    public void UpdateAnimatorValues(Vector2 movementInput, bool isSprinting)
    {
        float targetValue = 0;
        
        float moveAmount = movementInput.magnitude;

        if (moveAmount > 0)
        {
            if (isSprinting)
            {
                targetValue = 1.0f;
            }
            else
            {
                targetValue = 0.5f;
            }
        }
        else
        {
            targetValue = 0;
        }
        animator.SetFloat(speedHash, targetValue, 0.1f, Time.deltaTime);
    }
}