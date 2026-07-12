using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float speed = 8f;
    public float fireRate = 0.3f;

    private Rigidbody rb;
    private float nextFireTime = 0f;

    // 道具状态
    private bool isShielded = false;       // 护盾激活中
    private float shieldTimer = 0f;
    private bool isSpeedBoosted = false;   // 加速中
    private float speedBoostTimer = 0f;

    void Start() { rb = GetComponent<Rigidbody>(); }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveX * speed, 0, 0);
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -10f, 10f);
        transform.position = pos;

        // 射击（加速时射速翻倍）
        float currentFireRate = isSpeedBoosted ? fireRate / 2f : fireRate;
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + currentFireRate;
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }

        // 护盾计时
        if (isShielded)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0) isShielded = false;
        }

        // 加速计时
        if (isSpeedBoosted)
        {
            speedBoostTimer -= Time.deltaTime;
            if (speedBoostTimer <= 0) isSpeedBoosted = false;
        }
    }

    public void ActivateSpeedBoost(float duration)
    {
        isSpeedBoosted = true;
        speedBoostTimer = duration;
    }

    public void ActivateShield(float duration)
    {
        isShielded = true;
        shieldTimer = duration;
    }

    public bool HasShield() { return isShielded; }
}
