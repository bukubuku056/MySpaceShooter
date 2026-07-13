using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float startInterval = 2f;
    public float minInterval = 0.5f;
    public float baseSpeed = 3f;
    public float maxSpeed = 8f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (!GameManager.Instance.IsPlaying())
            {
                yield return new WaitForSeconds(0.1f);
                continue;
            }

            int currentScore = GameManager.Instance.GetScore();
            float interval = Mathf.Lerp(startInterval, minInterval, currentScore / 100f);
            float enemySpeed = Mathf.Lerp(baseSpeed, maxSpeed, currentScore / 100f);

            float randomX = Random.Range(-10f, 10f);
            Vector3 pos = new Vector3(randomX, 7f, 0);
            GameObject enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
            enemy.GetComponent<EnemyMover>().speed = enemySpeed;

            yield return new WaitForSeconds(interval);
        }
    }
}
