using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        // 敌机向下飞（3D的Y轴向下）
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 飞出屏幕 → 销毁
        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }
    }

    // 撞到玩家 → 游戏结束
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
