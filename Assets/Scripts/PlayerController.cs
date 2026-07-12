using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;      // 子弹发射位置（稍后创建空物体放这里）
    public float speed = 8f;
    public float fireRate = 0.3f;    // 每0.3秒才能发一颗子弹

    private Rigidbody rb;
    private float nextFireTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 左右移动（A/D 或 方向键）
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveX * speed, 0, 0);

        // 屏幕边界
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -10f, 10f);
        transform.position = pos;

        // 空格发射子弹
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}
