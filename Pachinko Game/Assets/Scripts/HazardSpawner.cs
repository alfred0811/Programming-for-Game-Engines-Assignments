using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public GameObject hazardPrefab; // Prefab to spawn
    public float spawnDelay = 5f;   // Seconds before spawning again

    public float minX = -3f;        // Horizontal spawn range
    public float maxX = 3f;
    public float minY = -2f;        // Vertical spawn range
    public float maxY = 2f;

    private float timer = 0f;

    void Update()
    {
        // Continously increment timer
        timer += Time.deltaTime;

        if (timer >= spawnDelay)
        {
            SpawnHazard();
            timer = 0f; // Reset timer
        }
    }

    void SpawnHazard()
    {
        Debug.Log("Spawning Hazard");
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        Vector2 pos = new Vector2(x, y);
        Instantiate(hazardPrefab, pos, Quaternion.identity);
    }
}
