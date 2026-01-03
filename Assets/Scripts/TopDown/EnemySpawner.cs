using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 2.0f;
    
    [SerializeField] private float minDistance = 5.0f; 
    
    [SerializeField] private float maxDistance = 10.0f;

    [Header("References")]
    [SerializeField] private Transform player;

    private void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) 
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("Player not found! Make sure your player has the 'Player' tag.");
            }
        }

        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (player == null) return;

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        float randomDistance = Random.Range(minDistance, maxDistance);

        Vector2 spawnPos = (Vector2)player.position + (randomDirection * randomDistance);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        if (player != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(player.position, minDistance);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(player.position, maxDistance);
        }
    }
}