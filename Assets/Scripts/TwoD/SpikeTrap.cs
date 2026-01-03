using System;
using UnityEditor;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public enum Direction
    {
        Vertical,
        Horizontal
    }

    public Direction trapDirection = Direction.Vertical;
    public float speed = 2.0f;
    public float range = 5.0f;
    public float rotationSpeed = 360.0f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        Vector2 dir = trapDirection == Direction.Horizontal ? Vector2.right : Vector2.up;

        float movement = speed * Time.deltaTime;
        float oscillation = (Mathf.Sin(Time.time * speed) * 0.5f + 0.5f) * range;
        transform.position = initialPosition + (Vector3)(dir * oscillation);

        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    
    private void OnDrawGizmos() {
        Vector3 dir = trapDirection == Direction.Horizontal ? Vector3.right : Vector3.up;
        Vector3 pos = Application.isPlaying ? initialPosition : transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos, pos + dir * range);
    }
}
