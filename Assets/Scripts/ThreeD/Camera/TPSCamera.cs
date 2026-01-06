using UnityEngine;
using UnityEngine.InputSystem; // Required for Mouse.current

public class TPSCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -4);
    [SerializeField] private float mouseSensitivity = 1.0f;
    [SerializeField] private float pitchMin = -30f;
    [SerializeField] private float pitchMax = 60f;

    private float yaw;
    private float pitch;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void LateUpdate()
    {
        if (playerTarget == null) return;

        HandleRotation();
        FollowPlayer();
    }

    void HandleRotation()
    {
        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            yaw += mouseDelta.x * mouseSensitivity;
            pitch -= mouseDelta.y * mouseSensitivity;

            pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);
        }
    }

    void FollowPlayer()
    {
        Quaternion currentRotation = Quaternion.Euler(pitch, yaw, 0);

        Vector3 desiredPosition = playerTarget.position + (currentRotation * offset);

        transform.position = desiredPosition;
        transform.LookAt(playerTarget.position + Vector3.up * 1.5f);
    }
}