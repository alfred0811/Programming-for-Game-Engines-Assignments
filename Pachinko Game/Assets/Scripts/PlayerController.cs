using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private float maxDistanceFromStart = 20.0f;
    private Vector3 startPosition = Vector3.zero;

    void Awake()
    {
        startPosition = transform.position;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            position.x += moveSpeed * Time.deltaTime;
        }

        // position.x = Mathf.Clamp(distanceFromStart) > maxDistanceFromStart
        float distanceFromStart = position.x - startPosition.x;
        if (Mathf.Abs(distanceFromStart) > maxDistanceFromStart)
        {
            if (distanceFromStart < 0)
            {
                position.x = startPosition.x - maxDistanceFromStart;
            }
            else
            {
                position.x = startPosition.x + maxDistanceFromStart;
            }
        }
        transform.position = position;
    }
}
