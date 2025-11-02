using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    private int pointValue = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                GameController.Instance.AddScore(pointValue);
                Destroy(gameObject);
            }
        }
    }
}
