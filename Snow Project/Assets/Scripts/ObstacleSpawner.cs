using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float obstacleSpawnRate;
    private float obstacleSpawnTimer;
    [SerializeField] private float obstacleSpeed;
    
    private float[] possibleRotations = { 0f, 45f, 90f, 135f };
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlaying)
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
        float spawnY = Random.Range(-6.5f, 6.5f);
        float randomRotation = possibleRotations[Random.Range(0, possibleRotations.Length)];
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, randomRotation);
        
        GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
        
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnY,0);
        GameObject spawnedObstacle = Instantiate(obstacle, spawnPosition, spawnRotation);
        
        Rigidbody2D rb = spawnedObstacle.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * obstacleSpeed;
    }
}
