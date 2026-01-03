using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public float health = 100.0f;
    Animator animator;
    private float horizontalInput;
    private float verticalInput;
    private Vector2 lastInput = new Vector2(0 , -1);
    private Vector2 movePosition = new Vector2(0 , -1);
    private bool isWalking = false;
    Rigidbody2D rb;
    [SerializeField] private float moveSpeed =3.0f;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(health);
        ReadInput();
        UpdateAnimator();
    }
    void FixedUpdate()
    {
        UpdateMovement();
    }
    private void ReadInput()
    {
        movePosition.x = Input.GetAxisRaw("Horizontal");
        movePosition.y = Input.GetAxisRaw("Vertical");
        if(movePosition.x != 0 || movePosition.y != 0)
        {
            isWalking =true;
            lastInput = movePosition;
        }
        else 
        if(movePosition.x == 0 && movePosition.y == 0)
        {
            isWalking =false;
        }
    }
    private void UpdateAnimator()
    {
        if(isWalking)
        {
            animator.SetFloat("walkX" ,movePosition.x );
            animator.SetFloat("walkY" ,movePosition.y );
        }
        else
        {
            animator.SetFloat("idleX" ,lastInput.x );
            animator.SetFloat("idleY" ,lastInput.y );
        }
        animator.SetBool("isMoving" , isWalking);
    }
    private void UpdateMovement()
    {
        Vector2 newPosition = rb.position + movePosition.normalized * moveSpeed * Time.deltaTime; 
        rb.MovePosition(newPosition);
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            health -=20.0f;
        }
    }
}
