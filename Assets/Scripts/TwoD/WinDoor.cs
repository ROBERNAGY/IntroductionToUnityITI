using UnityEngine;

public class WinDoor : MonoBehaviour
{
    [SerializeField] private CharacterController2D player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(player.hasTheKey)
            {
                Debug.Log("GG");
            }
            else
            {
                 Debug.Log("Find the Key");
            }
        }
    }
}
