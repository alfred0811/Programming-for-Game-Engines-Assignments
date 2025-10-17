using UnityEngine;

public class DynamicObstacleController : MonoBehaviour
{
    // Enum to define movement direction in the Inspector
    // MovementDirection function is a unity specific type of enum
    public enum MovementDirection { Horizontal, Vertical }
    [SerializeField] private MovementDirection movementDirection = MovementDirection.Horizontal;

    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float movementRange = 2.0f;

    private Vector3 startPosition;
    private bool movingForward = true;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        Vector3 position = transform.position;

        if (movementDirection == MovementDirection.Horizontal)
        {
            if (movingForward)
                position.x += moveSpeed * Time.deltaTime;
            else
                position.x -= moveSpeed * Time.deltaTime;

            if (Mathf.Abs(position.x - startPosition.x) >= movementRange)
                movingForward = !movingForward;
        }
        else // Vertical movement
        {
            if (movingForward)
                position.y += moveSpeed * Time.deltaTime;
            else
                position.y -= moveSpeed * Time.deltaTime;

            if (Mathf.Abs(position.y - startPosition.y) >= movementRange)
                movingForward = !movingForward;
        }

        transform.position = position;
    }
}
