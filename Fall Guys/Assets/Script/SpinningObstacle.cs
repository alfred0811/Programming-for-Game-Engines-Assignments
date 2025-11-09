using UnityEngine;

public class SpinningObstacle : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 100.0f; // Degrees per second
    [SerializeField]
    private bool clockwise = true; // Direction of rotation
    [SerializeField]
    private Vector3 rotationAxis = Vector3.forward; // Axis of rotation
    [SerializeField]
    private float knockbackForce = 10.0f; // Force applied to the player on collision

    private void Update()
    {
        float direction = clockwise ? -1.0f : 1.0f;

        transform.Rotate(rotationAxis, direction * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // Calculate knockback direction (away from the obstacle)
                Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized;

                // Apply the knockback force
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}
