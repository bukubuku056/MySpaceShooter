using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1.5f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float randomX = Random.Range(-10f, 10f);
            Vector3 pos = new Vector3(randomX, 7f, 0);
            Instantiate(enemyPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
