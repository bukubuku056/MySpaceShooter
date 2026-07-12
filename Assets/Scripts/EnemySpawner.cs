using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float startInterval = 2f;     // 初始2秒一个
    public float minInterval = 0.5f;     // 最快0.5秒一个
    public float baseSpeed = 3f;         // 敌机初始速度
    public float maxSpeed = 8f;          // 敌机最快速度

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // 根据分数计算当前间隔和速度
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
