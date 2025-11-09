using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [Header("Swing Settings")]
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float limit = 75.0f;
    [SerializeField]
    private bool randomStart = false;

    [Header("Obstacle Settings")]
    [SerializeField]
    private float knockbackForce = 10.0f;

    private float random = 0.0f;

    private void Awake()
    {
        if (randomStart)
        {
            random = Random.Range(0.0f, 1.0f);
        }
    }

    void Update()
    {
        float angle = limit * Mathf.Sin((Time.time + random) * speed);
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized;
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}
