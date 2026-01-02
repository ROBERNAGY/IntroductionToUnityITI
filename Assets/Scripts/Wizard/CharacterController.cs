using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class CharacterController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private Transform playerTransform;

    private float moveInput;
    private bool jumpRequested;
    private bool isGrounded;
    private float initialScaleX;

    private static readonly int IsRunHash = Animator.StringToHash("isRun");
    private static readonly int IsJumpHash = Animator.StringToHash("isJump");


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerTransform = transform;
        initialScaleX = playerTransform.localScale.x;
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            jumpRequested = true;

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        animator.SetBool(IsRunHash, moveInput != 0);
        if (isGrounded)
            animator.ResetTrigger(IsJumpHash);
        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (jumpRequested && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger(IsJumpHash);
        }

        jumpRequested = false;
    }

    private void Flip()
    {
        if (moveInput == 0) return;

        float direction = Mathf.Sign(moveInput);
        playerTransform.localScale = new Vector3(
            initialScaleX * direction,
            playerTransform.localScale.y,
            playerTransform.localScale.z
        );
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
