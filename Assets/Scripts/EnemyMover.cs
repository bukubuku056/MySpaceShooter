using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 3f;
    public GameObject[] powerUpPrefabs;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -8f) Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null && player.HasShield())
            {
                Destroy(gameObject);
                return;
            }
            GameManager.Instance.GameOver();
        }
    }
}
