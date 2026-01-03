using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private CharacterController2D player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.alive = false;
        }
    }
}
