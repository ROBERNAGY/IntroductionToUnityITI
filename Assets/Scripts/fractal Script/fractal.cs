using UnityEngine;

public class FractalSpawner : MonoBehaviour
{
    [Header("Prefab Settings")]
    public GameObject prefab;       // Assign your prefab in the Inspector

    [Header("Fractal Settings")]
    public int depth = 3;           // How many recursive levels
    public float offset = 2f;       // Distance between spawned objects
    public float scaleVariation = 0.5f; // Random scale variation
    public bool randomRotation = true;

    void Start()
    {
        // Start spawning at the GameObject's position
        SpawnFractal(transform.position, depth);
    }

    void SpawnFractal(Vector3 position, int currentDepth)
    {
        if (currentDepth <= 0 || prefab == null) return;

        // Instantiate the prefab
        GameObject obj = Instantiate(prefab, position, Quaternion.identity);

        // Apply random rotation
        if (randomRotation)
            obj.transform.rotation = Random.rotation;

        // Apply random scale
        float scale = 1f - (depth - currentDepth) * scaleVariation;
        obj.transform.localScale = Vector3.one * scale;

        // Directions to spawn next level
        Vector3[] directions = {
            Vector3.forward, Vector3.back,
            Vector3.left, Vector3.right,
            Vector3.up, Vector3.down
        };

        // Recursively spawn in each direction
        foreach (Vector3 dir in directions)
        {
            Vector3 newPos = position + dir * offset * scale;
            SpawnFractal(newPos, currentDepth - 1);
        }
    }
}
