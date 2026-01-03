using UnityEngine;

public class Bow : MonoBehaviour
{
    private Camera mainCam;

    [Header("Settings")]
    public float rotationOffset = 0f;

    [Header("Shooting Setup")]
    public GameObject arrowPrefab;
    public Transform firePoint;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        RotateToMouse();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void RotateToMouse()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        float distanceToScreen = mainCam.WorldToScreenPoint(transform.position).z;
        mouseScreenPosition.z = distanceToScreen;

        Vector3 mouseWorldPosition = mainCam.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 direction = mouseWorldPosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + rotationOffset);
    }

    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}