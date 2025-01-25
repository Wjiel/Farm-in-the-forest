using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private Transform[] EnemySpawnPoint;
    private void OnEnable(){
        DayNight.startNightAction += StartSpawn;
    }
    
    private void OnDisable() {
         DayNight.startNightAction -= StartSpawn;
    }

    private void StartSpawn()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        Instantiate(EnemyPrefab,
        EnemySpawnPoint[Random.Range(0, EnemySpawnPoint.Length)].position,
        Quaternion.identity);

        yield return null;
    }
}