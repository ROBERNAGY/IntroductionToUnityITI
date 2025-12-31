using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;
using System.Linq.Expressions;

public class CarManager : MonoBehaviour
{
    [SerializeField] private List<Transform> carWheels;
    [SerializeField] float rotationSpeed = 400f;
    [SerializeField] float carSpeed = 20f;
    private Transform _carTransfrom;
    [SerializeField] private Vector3 _direction;
    public Vector3 direction
    {
        set{_direction = value;}
    }
    public Transform carTransform
    {
        set{  
            _carTransfrom = value;
             if (_carTransfrom != null)
            {
                transform.position = _carTransfrom.position;
            }
        }
    }
    private
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnEnable()
    {
        _carTransfrom = GetComponent<Transform>();
        HandleDirection();
    }
    // Update is called once per frame
    void Update()
    {
        RotateWheels();
        Move();
    }
    private void HandleDirection()
    {
         float yRotation = _carTransfrom.eulerAngles.y;

        if (_direction.z == 1 && yRotation  == 180.0f)
        {
            _carTransfrom.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (_direction.z == -1 && yRotation == 0.0f)
        {
           _carTransfrom.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
    private void RotateWheels()
    {
        foreach (Transform wheel in carWheels)
        {
            wheel.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
    }
}
