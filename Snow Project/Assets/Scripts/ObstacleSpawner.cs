using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float obstacleSpawnRate;
    private float obstacleSpawnTimer = 0f;
    [SerializeField] private float obstacleSpeed;
    
    // Update is called once per frame
    void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        obstacleSpawnTimer += Time.deltaTime;
        if (obstacleSpawnTimer >= obstacleSpawnRate)
        {
            Spawn();
            obstacleSpawnTimer = Random.Range(0f, obstacleSpawnRate-1);
        }
    }

    private void Spawn()
    {
        GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
        GameObject spawnedObstacle = Instantiate(obstacle, transform.position, Quaternion.identity);
        
        Rigidbody2D rb = spawnedObstacle.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * obstacleSpeed;
    }
}
