using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
           
            GameController.Instance.SetLastCheckpoint(this);

            Debug.Log("Checkpoint reached at: " + transform.position);
        }
    }
}