using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int pointValue = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddToScore(pointValue);
            }
            Destroy(gameObject);
        }
    }
}