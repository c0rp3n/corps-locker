using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

class Cave : Generator
{
    int fillProbability;
    int maxAdjR1;
    int maxAdjR2;
    int maxSizeX;
    int smoothingPasses;

    private TileType[,] mapGen;

    Cave(int level, int seed = 0x1DC5)
    {
        this.level = level;
        this.seed = seed;

        this.maxAdjR1 = 5;
        this.maxAdjR2 = 2;
        this.minSize = 0;
        this.maxSize = 64;
        this.maxSizeX = 96;
        this.smoothingPasses = 15;
    }

    ~Cave()
    {

    }

    public void Generate()
    {
        int levelSeed = seed + level;
        Random.InitState(levelSeed);

        map = new TileType[maxSizeX, maxSize];
        mapGen = new TileType[maxSizeX, maxSize];

        InitMap();

        for (int i = 0; i < smoothingPasses; i++)
        {
            SmoothingPass();
        }

        mapGen = null;
    }

    private void InitMap()
    {
        for (int x = 1; x < maxSizeX - 1; x++)
        {
            for (int y = 1; y < maxSize - 1; y++)
            {
                map[x, y] = RandPick();
            }
        }

        for (int x = 0; x < maxSizeX; x++)
        {
            for (int y = 0; y < maxSize; y++)
            {
                mapGen[x, y] = TileType.Wall;
            }
        }

        for (int y = 0; y < maxSize; y++)
        {
            map[y, 0] = map[y, maxSizeX - 1] = TileType.Wall;
        }

        for (int x = 0; x < maxSizeX; x++)
        {
            map[0, x] = map[maxSize - 1, x] = TileType.Wall;
        }
    }

    public void SmoothingPass()
    {
        for (int x = 1; x < maxSizeX - 1; x++)
        {
            for (int y = 1; y < maxSize - 1; y++)
            {
                int adjCountR1 = 0;
                int adjCountR2 = 0;

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (map[x + i, y + j] != TileType.Floor)
                            adjCountR1++;
                    }
                }
                for (int i = x - 2; i <= x + 2; i++)
                {
                    for (int j = y - 2; j <= y + 2; j++)
                    {
                        if (Mathf.Abs(i - x) == 2 && Mathf.Abs(j - y) == 2)
                            continue;
                        if (i < 0 || j < 0 || x >= maxSizeX || y >= maxSize)
                            continue;
                        if (map[x + i, y + j] != TileType.Floor)
                            adjCountR2++;
                    }
                }

                if (adjCountR1 >= maxAdjR1 || adjCountR2 <= maxAdjR2)
                    mapGen[x, y] = TileType.Wall;
                else
                    mapGen[x, y] = TileType.Floor;
            }
        }

        for (int x = 0; x < maxSizeX; x++)
        {
            for (int y = 0; y < maxSize; y++)
            {
                map[x, y] = mapGen[x, y];
            }
        }
    }

    private TileType RandPick()
    {
        if (Random.Range(1, 100) < fillProbability)
            return TileType.Wall;

        return TileType.Floor;
    }

    public override bool ValidTile(int x, int y)
    {
        if (x < minSize)
            return false;

        if (x >= maxSizeX)
            return false;

        if (y < minSize)
            return false;

        if (y >= maxSize)
            return false;

        return true;
    }
}
