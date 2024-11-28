using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class BackgroundTileManager : MonoBehaviour
{
    public GameObject groundTilePrefab; // Prefab for ground tiles
    public Transform player; // Reference to the player
    public float tileLength = 10f; // Length of a single tile
    public int initialTileCount = 5; // How many tiles to start with
    public float spawnThreshold = 10f; // Distance ahead of the player to spawn new tiles

    private Queue<GameObject> activeTiles = new Queue<GameObject>();
    private float spawnZ = 0f; // Z position for the next tile
    private float lastPlayerZ; // To track player's last position for despawning

    void Start()
    {
        // Spawn initial tiles
        for (int i = 0; i < initialTileCount; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        // If the player has passed the first tile in the queue by the tile length
        if (player.position.x > activeTiles.Peek().transform.position.x + tileLength)
        {
            // Remove the oldest tile
            DespawnTile();

            // Spawn a new tile at the end of the queue (right after the last tile)
            SpawnTile();
        }
    }

    void SpawnTile()
    {
        // Instantiate a new tile at the spawn position
        GameObject newTile = Instantiate(groundTilePrefab, new Vector3(spawnZ, 0, 0), Quaternion.identity);
        activeTiles.Enqueue(newTile);
        spawnZ += tileLength; // Move spawn position forward
    }

    void DespawnTile()
    {
        // Remove the oldest tile
        GameObject oldTile = activeTiles.Dequeue();
        Destroy(oldTile);
    }
}
