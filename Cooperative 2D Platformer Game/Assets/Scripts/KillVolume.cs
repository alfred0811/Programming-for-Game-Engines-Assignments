using UnityEngine;

public class KillVolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                // Reset the player's position to the starting point
                GameController.Instance.KillPlayer(player);
            }
        }
    }
}
