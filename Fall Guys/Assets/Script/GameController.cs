using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private Vector3 lastCheckpointPosition;
    private PlayerController playerController;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        if (playerController != null)
            lastCheckpointPosition = playerController.transform.position;
    }

    public void SetLastCheckpoint(Checkpoint checkpoint)
    {
        lastCheckpointPosition = checkpoint.transform.position;
        Debug.Log("New checkpoint set at " + lastCheckpointPosition);
    }

    public void KillPlayer(PlayerController player)
    {
        if (playerController == null)
            playerController = player;

        playerController.transform.position = lastCheckpointPosition;
        Debug.Log("Player respawned at " + lastCheckpointPosition);
    }

    public void EndGame()
    {
        Debug.Log("Game finished!");

        Time.timeScale = 0f;
    }
}
