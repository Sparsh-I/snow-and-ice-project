using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject tilePrefab; // Prefab of the background tile
    public int tileCount = 3; // Number of tiles to keep active
    public float tileWidth = 10f; // Width of each tile
    public float scrollSpeed = 5f; // Speed at which tiles move

    private Transform[] tiles; // Array to store active tiles

    void Start()
    {
        // Initialize tiles array and spawn initial tiles
        tiles = new Transform[tileCount];
        for (int i = 0; i < tileCount; i++)
        {
            GameObject tile = Instantiate(tilePrefab, new Vector3(i * tileWidth, 0, 0), Quaternion.identity);
            tiles[i] = tile.transform;
        }
    }

    void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            // Move tiles left
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].position += Time.deltaTime * scrollSpeed * Vector3.left;

                // Recycle tile when it moves offscreen
                if (tiles[i].position.x < -tileWidth)
                {
                    // Move tile to the right end
                    float rightmostX = GetRightmostTileX();
                    tiles[i].position = new Vector3(rightmostX + tileWidth, tiles[i].position.y, tiles[i].position.z);
                }
            }
        }
    }

    float GetRightmostTileX()
    {
        // Find the rightmost tile
        float maxX = float.MinValue;
        foreach (Transform tile in tiles)
        {
            if (tile.position.x > maxX)
            {
                maxX = tile.position.x;
            }
        }
        return maxX;
    }
}