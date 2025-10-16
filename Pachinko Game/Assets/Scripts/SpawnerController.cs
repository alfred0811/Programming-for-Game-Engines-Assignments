using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject ballPrefab;
    public float moveSpeed = 8f;
    public float leftX = -3.5f;
    public float rightX = 3.5f;
    public float yFixed = 4f;
    public float cooldown = 0.15f;

    float lastSpawnTime = 0f;

    void Update()
    {
        Vector3 p = transform.position;
        float input = Input.GetAxisRaw("Horizontal");
        p.x += input * moveSpeed * Time.deltaTime;
        p.x = Mathf.Clamp(p.x, leftX, rightX);
        p.y = yFixed;
        transform.position = p;


        if (Input.GetKey(KeyCode.Space) && Time.time - lastSpawnTime > cooldown)
        {
            if (ballPrefab != null)
                Instantiate(ballPrefab, transform.position, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
}
