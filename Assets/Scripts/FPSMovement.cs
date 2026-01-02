using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public Transform cam;                 // reference camera (for movement direction)
    public Transform groundCheck;
    public LayerMask groundMask;

    [Header("Movement")]
    public float walkSpeed = 6f;
    public float sprintSpeed = 9f;
    public float acceleration = 25f;

    [Header("Jump")]
    public float jumpForce = 5.5f;
    public float groundCheckRadius = 0.2f;

    [Header("Drag")]
    public float groundDrag = 6f;
    public float airDrag = 0f;

    Rigidbody rb;
    bool jumpQueued;
    bool grounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Ground check (cheap + stable)
        grounded = Physics.CheckSphere(
            groundCheck.position,
            groundCheckRadius,
            groundMask,
            QueryTriggerInteraction.Ignore
        );

        if (Input.GetButtonDown("Jump") && grounded)
            jumpQueued = true;
    }

    void FixedUpdate()
    {
        rb.linearDamping = grounded ? groundDrag : airDrag;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Move relative to camera facing (ignore camera pitch)
        Vector3 forward = cam.forward; forward.y = 0f; forward.Normalize();
        Vector3 right = cam.right;     right.y = 0f;   right.Normalize();

        Vector3 moveDir = (forward * z + right * x).normalized;

        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        Vector3 targetVel = moveDir * speed;

   
        Vector3 currentVel = rb.linearVelocity;
        Vector3 currentHorizontal = new Vector3(currentVel.x, 0f, currentVel.z);

        Vector3 velChange = targetVel - currentHorizontal;

        float maxChange = acceleration * Time.fixedDeltaTime;
        velChange = Vector3.ClampMagnitude(velChange, maxChange);

        rb.AddForce(velChange, ForceMode.VelocityChange);

        if (jumpQueued)
        {
            jumpQueued = false;

            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
