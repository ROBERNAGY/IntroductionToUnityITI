using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]Transform player;
    Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = player.GetComponent<Transform>();
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = new Vector3(player.position.x, player.position.y, cameraTransform.position.z);
    }
}
