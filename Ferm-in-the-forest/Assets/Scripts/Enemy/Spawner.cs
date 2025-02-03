using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private NavMeshSurface Surface;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private Transform[] EnemySpawnPoint;
    [SerializeField] private float Rate;

    public int countEnemy;
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
        Surface.BuildNavMesh();

        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        for (int i = 0; i < countEnemy; i++)
        {
            int randomPoint = Random.Range(0, EnemySpawnPoint.Length);
            Instantiate(EnemyPrefab,
         new Vector3(EnemySpawnPoint[randomPoint].position.x + Random.Range(-5f, 5f), EnemySpawnPoint[randomPoint].position.y, EnemySpawnPoint[randomPoint].position.z + Random.Range(-5f, 5f)),
            Quaternion.identity).GetComponent<Enemy>().Init(target);
            yield return new WaitForSeconds(Rate);
        }
    }

}