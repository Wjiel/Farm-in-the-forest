using System.Collections;
using UnityEngine;

/// <summary>
/// Класс для спавна врагов.
/// </summary>
public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemySpawner enemySpawner;

    [SerializeField] private Transform target;

    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private int enemyCount = 5;


    private void OnEnable()
    {
        DayNight.startNightAction += StartSpawn;
    }

    private void OnDisable()
    {
        DayNight.startNightAction -= StartSpawn;
    }

    private void StartSpawn()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Spawn();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void Spawn()
    {
        GameObject enemy = enemySpawner.SpawnEnemy(target);

        if (enemy.TryGetComponent(out Enemy enemyComponent))
            enemyComponent.Init(target);
    }
}