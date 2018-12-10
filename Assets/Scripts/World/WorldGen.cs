using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGen : MonoBehaviour
{
    public const int chunkSize = 16;
    public const int octaves = 8;

    List<Chunk> chunks;

    Tilemap tileMap;

    // Use this for initialization
	void Start ()
    {
        tileMap = GameObject.Find("WorldMap").GetComponent<Tilemap>();
        tileMap.ClearAllTiles();

        chunks = new List<Chunk>();
        GetChunk(new Vector2Int(0, 0));
        GetChunk(new Vector2Int(-chunkSize, 0));
        GetChunk(new Vector2Int(0, -chunkSize));
        GetChunk(new Vector2Int(-chunkSize, -chunkSize));
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void CheckChunks()
    {
        for (int i = 0; i < chunks.Capacity; i++)
        {
            if (chunks[i].IsChunkVisible() == false)
            {
                RemoveChunk(i);
                break;
            }
        }


    }

    void GetChunk(Vector2Int position)
    {
        CreateChunk(position);
    }

    void CreateChunk(Vector2Int position)
    {
        Chunk chunk = new Chunk(position);
        chunks.Add(chunk);

        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                //tileMap.SetTile(new Vector3Int(chunk.location.x + x, chunk.location.y + y, 0), chunk.tiles[x, y].CreateTile());
            }
        }
    }

    void LoadChunk()
    {

    }

    void RemoveChunk(int index)
    {
        
        chunks.RemoveAt(index);
    }
}
