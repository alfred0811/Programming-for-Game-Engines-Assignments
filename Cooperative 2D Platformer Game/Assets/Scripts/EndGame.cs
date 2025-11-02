using UnityEngine;

public class EndGame : MonoBehaviour
{
    private bool gameEnded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameEnded || collision == null)
            return;

        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            EndLevel();
        }
    }

    private void EndLevel()
    {
        gameEnded = true;
        Debug.Log("Level Completed!");

        // Disable all PlayerController scripts so players stop responding
        // Unity 6+: prefer FindObjectsByType for better performance/control
        PlayerController[] players = Object.FindObjectsByType<PlayerController>
        (
            FindObjectsInactive.Include,
            FindObjectsSortMode.None
        );

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
                players[i].enabled = false;
        }

        // pause the game
        Time.timeScale = 0f;
    }
}
