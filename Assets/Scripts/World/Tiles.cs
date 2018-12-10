using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tiles
{
    private static readonly Tiles instance = new Tiles();

    static Tiles()
    {
    }

    private Tiles()
    {
        TileListGen();
    }

    public static Tiles Instance
    {
        get
        {
            return instance;
        }
    }

    // tile lists one per folder / type
    public Sprite[] cliffs;
    public Sprite[] dirt;
    public Sprite[] grass;
    public Sprite[] rock;
    public Sprite[] sand;
    public Sprite[] snow;
    public Sprite[] water;

    // tile list generator
    public void TileListGen()
    {
        cliffs = TileFinder("Bitmaps/World/Cliffs");
        dirt = TileFinder("Bitmaps/World/Dirt");
        grass = TileFinder("Bitmaps/World/Grass");
        rock = TileFinder("Bitmaps/World/Rock");
        sand = TileFinder("Bitmaps/World/Sand");
        snow = TileFinder("Bitmaps/World/Snow");
        water = TileFinder("Bitmaps/World/Water");
    }

    public Sprite[] TileFinder(string folder)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(folder);
        /*
        Tile[] tiles = new Tile[sprites.Length];

        for (int i = 0; i < sprites.Length; i++)
        {
            Tile tile = new Tile();
            tile.sprite = sprites[i];

            tiles[i] = tile;
        }
        */

        return sprites;
    }
}

public struct WorldTile
{
    enum TileType
    {
        Cliffs,
        Dirt,
        Grass,
        Rock,
        Sand,
        Snow,
        Water,
    }

    TileType type; // stores the region type
    int variant; // stores what texture variant was used.

    WorldTile(TileType _type, int _variant)
    {
        type = _type;
        variant = _variant;
    }

    public static WorldTile GetWorldTile(float height, float moisture)
    {
        Tiles tiles = Tiles.Instance;

        if (height < 0.075f) // DEEP_WATER
        {
            return new WorldTile(TileType.Water, 6);
        }
        else if (height < 0.1f) // WATER
        {
            return new WorldTile(TileType.Water, 6);
        }
        else if (height < 0.14f) // BEACH
        {
            return new WorldTile(TileType.Sand, Random.Range(0, tiles.sand.Length));
        }
        else if (height < 0.3f)
        {
            if (moisture < 0.16f) // SUBTROPICAL_DESERT
            {
                return new WorldTile(TileType.Sand, Random.Range(0, tiles.sand.Length));
            }
            else if (moisture < 0.33f) // GRASSLAND
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
            else if (moisture < 0.66f) // TROPICAL_SEASONAL_FOREST
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
            else // TROPICAL_SEASONAL_FOREST
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
        }
        else if (height < 0.6f)
        {
            if (moisture < 0.16f) // TEMPERATE_DESERT
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
            else if (moisture < 0.50f) // GRASSLAND
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
            else if (moisture < 0.83f) // TEMPERATE_DECIDUOUS_FOREST
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
            else // TEMPERATE_RAIN_FOREST
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
        }

        else if (height < 0.8f)
        {
            if (moisture < 0.33f) // TEMPERATE_DESERT
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
            else if (moisture < 0.66f) // SHRUBLAND
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
            else // TAIGA
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
        }
        else
        {
            if (moisture < 0.1f) // SCORCHED
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
            else if (moisture < 0.2f) // BARE
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
            else if (moisture < 0.5f) // TUNDRA
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
            else // SNOW
            {
                return new WorldTile(TileType.Snow, Random.Range(0, tiles.snow.Length));
            }
        }
    }
}
