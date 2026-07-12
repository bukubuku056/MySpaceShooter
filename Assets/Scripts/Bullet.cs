using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public GameObject explosionPrefab;
    private bool hasHit = false;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > 8f) Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;
        if (other.CompareTag("Enemy"))
        {
            hasHit = true;

            // 爆炸特效
            if (explosionPrefab != null)
            {
                GameObject fx = Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
                Destroy(fx, 1f);
            }

            // 30%概率掉落道具
            EnemyMover enemy = other.GetComponent<EnemyMover>();
            if (enemy != null && enemy.powerUpPrefabs != null && enemy.powerUpPrefabs.Length > 0)
            {
                if (Random.value < 0.3f)
                {
                    int index = Random.Range(0, enemy.powerUpPrefabs.Length);
                    Instantiate(enemy.powerUpPrefabs[index], other.transform.position, Quaternion.identity);
                }
            }

            Destroy(other.gameObject);
            GameManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}
