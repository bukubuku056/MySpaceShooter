using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type { Health, Speed, Shield }
    public Type powerUpType = Type.Health;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            switch (powerUpType)
            {
                case Type.Health:
                    GameManager.Instance.AddScore(5);   // 血包+5分
                    break;
                case Type.Speed:
                    player.ActivateSpeedBoost(5f);       // 加速5秒
                    break;
                case Type.Shield:
                    player.ActivateShield(5f);           // 护盾5秒
                    break;
            }

            Destroy(gameObject);
        }
    }

    // 超屏幕销毁
    void Update()
    {
        if (transform.position.y < -8f) Destroy(gameObject);
    }
}
