using UnityEngine;

public class CameraScript : MonoBehaviour
{
      public Transform playerCamera;
    public float sensitivity = 2f;
    public float maxPitch = 85f;

    float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mx = Input.GetAxis("Mouse X") * sensitivity;
        float my = Input.GetAxis("Mouse Y") * sensitivity;

        // Yaw on player body
        transform.Rotate(0f, mx, 0f);

        // Pitch on camera
        pitch -= my;
        pitch = Mathf.Clamp(pitch, -maxPitch, maxPitch);
        playerCamera.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        // Escape to unlock (optional)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
