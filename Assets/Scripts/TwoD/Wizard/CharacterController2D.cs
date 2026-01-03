using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class CharacterController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.15f;
    [SerializeField] private float dashCooldown = 1f;

    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Attack Settings")]
    [SerializeField] private float attackCoolDown = 3f;

    private Rigidbody2D rb;
    private Animator animator;
    private Transform playerTransform;

    public bool hasTheKey = false;
    public bool alive = true;
    private float moveInput;
    private bool jumpRequested;
    private bool isGrounded;
    private bool isDashing;
    private float dashCooldownTimer;
    private float attackCoolDownTimer;
    private float initialScaleX;

    private static readonly int IsRunHash = Animator.StringToHash("isRun");
    private static readonly int IsJumpHash = Animator.StringToHash("isJump");
    private static readonly int IsAttackHash = Animator.StringToHash("attack");

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerTransform = transform;
        initialScaleX = playerTransform.localScale.x;
    }

    private void Update()
    {
        attackCoolDownTimer += Time.deltaTime;
        dashCooldownTimer += Time.deltaTime;

        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
            jumpRequested = true;

        if (Input.GetKeyDown(KeyCode.Space) && attackCoolDownTimer >= attackCoolDown)
        {
            attackCoolDownTimer = 0f;
            animator.SetTrigger(IsAttackHash);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer >= dashCooldown && !isDashing)
        {
            StartCoroutine(Dash());
        }

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
        if (isDashing)
            return;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (jumpRequested && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger(IsJumpHash);
        }

        jumpRequested = false;
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        dashCooldownTimer = 0f;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        float dashDirection = Mathf.Sign(playerTransform.localScale.x);
        rb.linearVelocity = new Vector2(dashDirection * dashSpeed, 0f);

        yield return new WaitForSeconds(dashDuration);

        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        rb.gravityScale = originalGravity;
        isDashing = false;
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
