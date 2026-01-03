using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float destroyTime = 5.0f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        Destroy(gameObject , destroyTime);
    }
    void Update()
    {
        Vector2 forwardDirection = -transform.up;

        rb.linearVelocity = forwardDirection * speed;
    }
}
