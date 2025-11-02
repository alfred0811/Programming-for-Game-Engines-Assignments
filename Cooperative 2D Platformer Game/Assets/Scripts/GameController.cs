using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<PlayerController> playerController = new();
    private Vector3 lastCheckpointPosition = Vector3.zero;

    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private int score = 0;

    static private GameController instance = null;
    static public GameController Instance {  get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateScoreText();
    }

    private void Initialize()
    {
        if (playerController == null || playerController.Count == 0)
        {
            Debug.LogError("No PlayerControllers assigned in inspector");
            return;
        }
    }

    public void SetLastCheckpoint(Checkpoint checkpoint)
    {
        lastCheckpointPosition = checkpoint.transform.position;
    }

    public void KillPlayer(PlayerController player)
    {
        if (player == null)
        {
            Debug.LogError("PlayerController is null in KillPlayer");
            return;
        }
        KillAllPlayers();
    }

    public void KillAllPlayers()
    {
        if (playerController == null || playerController.Count == 0)
        {
            Debug.LogError("No PlayerControllers assigned when trying to KillAllPlayers");
            return;
        }

        for (int i = 0; i < playerController.Count; i++)
        {
            PlayerController player = playerController[i];
            if (player == null)
            {
                continue;
            }

            // Spread them horizontally by 1.5 units so they don't stack exactly on the same spot.
            Vector3 offset = new Vector3(i * 1.5f, 0f, 0f);
            player.transform.position = lastCheckpointPosition + offset;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
