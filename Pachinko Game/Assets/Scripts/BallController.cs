using UnityEngine;

public class BallController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if it's a Slot
        Slot slot = collision.GetComponent<Slot>();
        if (slot == null) slot = collision.GetComponentInParent<Slot>();
        if (slot != null)
        {
            if (GameManager.Instance != null)
                GameManager.Instance.AddToScore(slot.pointValue); 

            Destroy(gameObject); // Destroy the ball
            return;
        }

        // Check if it's a Pickup
        Pickup pickup = collision.GetComponent<Pickup>();
        if (pickup == null) pickup = collision.GetComponentInParent<Pickup>();
        if (pickup != null)
        {
            if (GameManager.Instance != null)
                GameManager.Instance.AddToScore(pickup.pointValue);

            Destroy(pickup.gameObject); // Destroys pickup
            return;
        }
    }
}
