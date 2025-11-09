using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform bottomPoint;
    [SerializeField]
    private Transform topPoint;
    [SerializeField] 
    private float speed = 1.5f;
    [SerializeField]
    private bool inverted = false;

    private float time;

    private void Update()
    {
        time += Time.deltaTime * speed;

        // goes from 0 to 1 and back to 0
        float ping = Mathf.PingPong(time, 1.0f);

        float lerpValue = inverted ? 1f - ping : ping;
    }
}
