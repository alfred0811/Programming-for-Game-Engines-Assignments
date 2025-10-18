using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] 
    private float rotationSpeed = 120f; // degrees per second
    [SerializeField] 
    private bool clockwise = true;      // direction toggle

    void Update()
    {
        // Rotation
        float direction = 1f;
        if (clockwise)
        {
            direction = -1f;
        }

        transform.Rotate(0f, 0f, direction * rotationSpeed * Time.deltaTime);
    }
}
