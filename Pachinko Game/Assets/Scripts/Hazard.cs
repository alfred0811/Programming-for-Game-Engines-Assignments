using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int penalty = 50; // Points to remove when player touches it

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance != null)
            GameManager.Instance.AddToScore(-penalty);

        Destroy(gameObject);
    }
}
