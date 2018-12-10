using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Generator
{
    public int minSize;
    public int maxSize;

    public int level;
    public int seed;

    public TileType[,] map;

    public void PlaceWalls()
    {
        int adjX, adjY;
        for (int x = minSize; x < maxSize; x++)
        {
            for (int y = minSize; y < maxSize; y++)
            {
                if (map[x, y] == TileType.Floor)
                    continue;

                adjX = x - 1;
                adjY = y + 1;
                if (ValidTile(adjX, adjY))
                {
                    if ((map[adjX, adjY] == TileType.Floor))
                    {
                        map[x, y] = TileType.Wall;
                        continue;
                    }
                }

                adjX = x;
                if (ValidTile(adjX, adjY))
                {
                    if ((map[adjX, adjY] == TileType.Floor))
                    {
                        map[x, y] = TileType.Wall;
                        continue;
                    }
                }

                adjX = x + 1;
                if (ValidTile(adjX, adjY))
                {
                    if ((map[adjX, adjY] == TileType.Floor))
                    {
                        map[x, y] = TileType.Wall;
                        continue;
                    }
                }

                adjX = x - 1;
                adjY = y;
                if (ValidTile(adjX, adjY))
                {
                    if ((map[adjX, adjY] == TileType.Floor))
                    {
                        map[x, y] = TileType.Wall;
                        continue;
                    }
                }

                adjX = x + 1;
                if (ValidTile(adjX, adjY))
                {
                    if ((map[adjX, adjY] == TileType.Floor))
                    {
                        map[x, y] = TileType.Wall;
                        continue;
                    }
                }

                adjX = x - 1;
                adjY = y - 1;
                if (ValidTile(adjX, adjY))
                {
                    if ((map[adjX, adjY] == TileType.Floor))
                    {
                        map[x, y] = TileType.Wall;
                        continue;
                    }
                }

                adjX = x;
                if (ValidTile(adjX, adjY))
                {
                    if ((map[adjX, adjY] == TileType.Floor))
                    {
                        map[x, y] = TileType.Wall;
                        continue;
                    }
                }

                adjX = x + 1;
                if (ValidTile(adjX, adjY))
                {
                    if ((map[adjX, adjY] == TileType.Floor))
                    {
                        map[x, y] = TileType.Wall;
                        continue;
                    }
                }
            }
        }
    }

    public virtual bool ValidTile(int x, int y)
    {
        return (x >= minSize || x < maxSize || y >= minSize || y < maxSize);
    }
}
