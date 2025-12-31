using UnityEngine;

public class DespawnCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
            other.gameObject.SetActive(false);
    }
}
