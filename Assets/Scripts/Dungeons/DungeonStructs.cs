using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DungeonType
{
    public string dungeonName;
    public int roomCount;
    public DungeonTile dungeonFloorTile;
    public DungeonTile dungeonWallTile;

    public DungeonType(string dungeonName, int roomCount, ref DungeonTile dungeonFloorTile, ref DungeonTile dungeonWallTile)
    {
        this.dungeonName = dungeonName;
        this.roomCount = roomCount;
        this.dungeonFloorTile = dungeonFloorTile;
        this.dungeonWallTile = dungeonWallTile;
    }
}

[Serializable]
public struct DungeonType_JSON
{
    string dungeon_name;
    int room_count;
    string dungeon_floor_tile;
    string dungeon_wall_tile;

    static DungeonType Parse(string json)
    {
        DungeonType_JSON tile = JsonUtility.FromJson<DungeonType_JSON>(json);
        return new DungeonType();
    }
}

public struct Room
{
    public RoomType roomType;
    public RectInt room;

    Room(RoomType roomType, int x, int y, int width, int height)
    {
        this.roomType = roomType;
        this.room = new RectInt(x, y, width, height);
    }
}

public struct RoomType
{
    public struct Item
    {
        public string itemID;
        public float spawnChance;
        public int minCount;
        public int maxCount;
    }

    public string roomID;
    public string roomName;
    public float spawnChance;
    public int minSize;
    public int maxSize;
    public int minDoorCount;
    public int maxDoorCount;
    public Item[] items;

    public RoomType(string roomID, string roomName, float spawnChance, int minSize, int maxSize, int minDoorCount, int maxDoorCount, RoomType.Item[] items)
    {
        this.roomID = roomID;
        this.roomName = roomName;
        this.spawnChance = spawnChance;
        this.minSize = minSize;
        this.maxSize = maxSize;
        this.minDoorCount = minDoorCount;
        this.maxDoorCount = maxDoorCount;
        this.items = items;
    }

    public RoomType(RoomType_JSON roomType)
    {
        this.roomID = roomType.room_id;
        this.roomName = roomType.room_name;
        this.spawnChance = roomType.spawn_chance;
        this.minSize = roomType.min_size;
        this.maxSize = roomType.max_size;
        this.minDoorCount = roomType.min_door_count;
        this.maxDoorCount = roomType.max_door_count;
        this.items = roomType.items;
    }

    public static RoomType Parse(string json)
    {
        return new RoomType();
    }

    public void Serialize()
    {

    }
}

[Serializable]
public struct RoomType_JSON
{
    struct RoomItem_JSON
    {
        public string item_id;
        public float spawn_chance;
        public int min_Count;
        public int max_count;
    }

    public readonly string room_id;
    public readonly string room_name;
    public readonly float spawn_chance;
    public readonly int min_size;
    public readonly int max_size;
    public readonly int min_door_count;
    public readonly int max_door_count;
    public readonly RoomType.Item[] items;

    RoomType_JSON(string roomID, string roomName, float spawnChance, int minSize, int maxSize, int minDoorCount, int maxDoorCount, RoomType.Item[] items)
    {
        this.room_id = roomID;
        this.room_name = roomName;
        this.spawn_chance = spawnChance;
        this.min_size = minSize;
        this.max_size = maxSize;
        this.min_door_count = minDoorCount;
        this.max_door_count = maxDoorCount;
        this.items = items;
    }

    RoomType_JSON(RoomType roomType)
    {
        this.room_id = roomType.roomID;
        this.room_name = roomType.roomName;
        this.spawn_chance = roomType.spawnChance;
        this.min_size = roomType.minSize;
        this.max_size = roomType.maxSize;
        this.min_door_count = roomType.minDoorCount;
        this.max_door_count = roomType.maxDoorCount;
        this.items = roomType.items;
    }
}

public struct DungeonTile
{
    public struct TileTextures
    {
        public readonly string aldebo;
        public readonly float metallic;
        public readonly float roughness;
        public readonly string normal;
    }
    
    public struct TileDefault
    {
        public readonly TileTextures textures;
    }
    
    public struct TileVariant
    {
        public readonly TileAdjacentType adjacentTileFlags;
        public readonly TileTextures textures;
    }

    public string tileID;
    public string tileName;
    public TileType tileType;
    public TileDefault defaults;
    public List<TileVariant> variants;

    public DungeonTile(string tileID, string tileName, TileType tileType, TileDefault defaults, List<TileVariant> variants)
    {
        this.tileID = tileID;
        this.tileName = tileName;
        this.tileType = tileType;
        this.defaults = defaults;
        this.variants = variants;
    }

    static DungeonTile Parse(string json)
    {
        DungeonTile_JSON tile = JsonUtility.FromJson<DungeonTile_JSON>(json);
        return new DungeonTile();
    }
}

[Serializable]
public struct DungeonTile_JSON
{
    [Serializable]
    public struct TileTextures_JSON
    {
        public readonly string aldebo;
        public readonly float metallic;
        public readonly float roughness;
        public readonly string normal;
    }

    [Serializable]
    public struct TileDefault_JSON
    {
        public readonly TileTextures_JSON textures;
    }

    [Serializable]
    public struct TileVariant_JSON
    {
        public readonly TileAdjacentType adjacent_tile_flags;
        public readonly TileTextures_JSON textures;
    }

    public readonly string tile_id;
    public readonly string tile_name;
    public readonly string tile_type;
    public readonly string[] adjacent_tile_flags;
    public readonly TileDefault_JSON defaults;
    public readonly TileVariant_JSON[] variants;
}
