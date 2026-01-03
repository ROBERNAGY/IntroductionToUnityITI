using System;
using UnityEngine;

public class TorchPickUp : MonoBehaviour
{
   
   [SerializeField] private GameObject torch;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            torch.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
