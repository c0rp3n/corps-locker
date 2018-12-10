using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CResources : MonoBehaviour
{
    public Dictionary<string, DungeonType> dungeonTypes = new Dictionary<string, DungeonType>
    {
        { "default", new DungeonType() },
    };

    public Dictionary<string, DungeonTile> dungeonTiles = new Dictionary<string, DungeonTile>
    {
        { "default", new DungeonTile() },
    };

    public Dictionary<string, RoomType> roomTypes = new Dictionary<string, RoomType>
    {
        // Key RoomType || RoomTypeProperties (MinSize, MaxSize, MinDoors, MaxDoors, RoomItems)
        { "default", new RoomType("default", "default", 1.0f, 5, 16, 1, 3, new RoomType.Item[0]) },

        //{ RoomType.Dungeon, new RoomType(5, 15, 1, 3, RoomItemType.Chest) },
        //{ RoomType.DungeonSmall, new RoomType(3, 11, 1, 3, RoomItemType.Chest) },
        //{ RoomType.DungeonLarge, new RoomType(5, 15, 1, 3, RoomItemType.Chest) },

        //{ RoomType.Shrine, new RoomType(5, 11, 1, 1, RoomItemType.Shrine) },

        //{ RoomType.Shop, new RoomType(5, 11, 1, 1, RoomItemType.None) },
        };

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public static CResources Instance()
    {
        return GameObject.Find("Resources").GetComponent<CResources>();
    }
}
