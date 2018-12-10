using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Chunk
{
    public int seed;
    public Vector2Int location;
    public WorldTile[,] tiles;

    public Chunk(Vector2Int loc)
    {
        seed = Random.Range(int.MinValue, int.MaxValue);
        location = loc;
        tiles = new WorldTile[WorldGen.chunkSize, WorldGen.chunkSize];

        //GeneratePerlinChunk();
        GenerateSimplexChunk();
    }

    private void GenerateSimplexChunk()
    {
        SimplexNoise noise = SimplexNoise.Instance;
        for (int x = 0; x < WorldGen.chunkSize; x++)
        {
            for (int y = 0; y < WorldGen.chunkSize; y++)
            {
                tiles[x, y] = WorldTile.GetWorldTile(noise.SimplexNoise3D(location.x + x, location.y + y, 16, WorldGen.octaves), noise.SimplexNoise3D(location.x + x, location.y + y, 0, WorldGen.octaves));
            }
        }
    }

    private void GeneratePerlinChunk()
    {
        PerlinNoise noise = PerlinNoise.Instance;
        for (int x = 0; x < WorldGen.chunkSize; x++)
        {
            for (int y = 0; y < WorldGen.chunkSize; y++)
            {
                tiles[x, y] = WorldTile.GetWorldTile(noise.PerlinNoise2D(location.x + x, location.y + y, 16, WorldGen.octaves), noise.PerlinNoise2D(location.x + x, location.y + y, 0, WorldGen.octaves));
            }
        }
    }

    public bool IsChunkVisible()
    {
        return IsChunkVisible(location);
    }

    public static bool IsChunkVisible(Vector2Int location)
    {
        float distanceFromCamera = Camera.current.ViewportToScreenPoint(new Vector3Int(location.x, location.y, 0)).sqrMagnitude;

        return distanceFromCamera < 1.25f ? true : false;
    }
}
