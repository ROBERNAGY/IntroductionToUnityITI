using System;
using Unity.Mathematics;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]Transform player;
    Transform cameraTransform;
    [SerializeField] float yUpperBound = 8;
    [SerializeField] float yLowerBound = 0;
    [SerializeField] float xUpperBound = 46;
    [SerializeField] float xLowerBound = -48;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = player.GetComponent<Transform>();
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float cameraY = math.clamp(player.position.y ,yLowerBound , yUpperBound);
        float cameraX = math.clamp(player.position.x ,xLowerBound , xUpperBound);
        cameraTransform.position = new Vector3(cameraX, cameraY, cameraTransform.position.z);
    }
}
