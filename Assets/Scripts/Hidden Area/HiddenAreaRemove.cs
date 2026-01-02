using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenAreaRemove : MonoBehaviour
{
    private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetTilemapAlpha(0f);
        }
    }



    void SetTilemapAlpha(float alpha)
    {
        Color color = tilemap.color;
        color.a = alpha;
        tilemap.color = color;
    }
}