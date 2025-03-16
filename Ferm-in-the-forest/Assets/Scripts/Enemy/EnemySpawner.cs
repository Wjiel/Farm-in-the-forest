using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnOffset = 5f;

    public GameObject SpawnEnemy(Transform target)
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points!");
            return null;
        }

        int randomPointIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomPointIndex];

        Vector3 spawnPosition = spawnPoint.position + new Vector3(
            Random.Range(-spawnOffset, spawnOffset),
            0f,
            Random.Range(-spawnOffset, spawnOffset)
        );

        return Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}