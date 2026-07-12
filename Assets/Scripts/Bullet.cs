using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;

    void Update()
    {
        // 子弹向上飞（3D的Y轴向上）
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // 飞出屏幕 → 销毁
        if (transform.position.y > 8f)
        {
            Destroy(gameObject);
        }
    }

    // 打到敌机 → 加分+销毁
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);       // 销毁敌机
            GameManager.Instance.AddScore(10);
            Destroy(gameObject);             // 销毁子弹自己
        }
    }
}
