using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private GameObject activeState = null;
    [SerializeField]
    private GameObject inactiveState = null;

    private bool isActive = false;
    private void Awake()
    {
        SetActive(false);
    }

    private void SetActive(bool active)
    {
        isActive = active;
        activeState.SetActive(active);
        inactiveState.SetActive(!active);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive)
        {
            return;
        }

        if (collision != null && collision.GetComponent<PlayerController>())
        {
            SetActive(true);
            GameController.Instance.SetLastCheckpoint(this);
        }
    }
}
