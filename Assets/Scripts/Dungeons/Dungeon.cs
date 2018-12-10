using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEditor;

public class Dungeon : Generator
{
    CResources resources = CResources.Instance();
    DungeonType dungeonType;

    private readonly int minRoomPosition = 0x0001;
    private readonly int maxRoomPosition = 0x00FE;
    
    public int roomTries = 15;

    public List<GameObject> roomGameObjects = new List<GameObject>();
    private List<RectInt> rooms = new List<RectInt>();

    public Dungeon(ref DungeonType dungeonType, int level, int seed = 0x1DC5)
    {
        this.dungeonType = dungeonType;
        this.level = level;
        this.seed = seed;

        this.minSize = 0x0000;
        this.maxSize = 0x00FF;
    }

    ~Dungeon()
    {
        
    }

    public void Generate()
    {
        int levelSeed = seed + level;
        Random.InitState(levelSeed);

        //map = new TileType[maxSize, maxSize];

        CreateRooms();
        CreateRoomMeshes();

        //PlaceFloors();
        //PlaceWalls();

        //PlaceGameObjects();
    }

    void ClearDungeon()
    {
        //map = new TileType[0, 0];
        rooms.Clear();


    }

    private int CreateRooms()
    {
        int count = 0;
        for (int i = 0; i < roomCount; i++)
        {
            for (int j = 0; j < roomTries; j++)
            {
                if (CreateRoom())
                {
                    count++;
                    break;
                }
            }
        }

        return count;
    }

    private bool CreateRoom()
    {
        RoomType currentRoomProps;
        if (!resources.roomTypes.TryGetValue("default", out currentRoomProps))
            return false;

        int height = Random.Range(currentRoomProps.minSize, currentRoomProps.maxSize);
        int width = Random.Range(currentRoomProps.minSize, currentRoomProps.maxSize);

        int x = Random.Range(minRoomPosition + width / 2, maxRoomPosition - width / 2);
        int y = Random.Range(minRoomPosition + height / 2, maxRoomPosition - height / 2);

        RectInt newRoom = new RectInt(x - (width / 2), y - (height / 2), width, height);
        foreach (RectInt room in rooms)
        {
            if (newRoom.xMin < room.xMax && newRoom.xMax > room.xMin &&
                newRoom.yMin < room.yMax && newRoom.yMax > room.yMin)
            {
                return false;
            }
        }

        rooms.Add(newRoom);

        return true;
    }

    private void PlaceFloors()
    {
        foreach (RectInt room in rooms)
        {
            for (int x = room.xMin; x < room.xMax; x++)
            {
                for (int y = room.yMin; y < room.yMax; y++)
                {
                    map[x, y] = TileType.Floor;
                }
            }
        }
    }

    private void CreateRoomMeshes()
    {
        int count = 0;
        foreach (RectInt room in rooms)
        {
            GameObject gameObject = new GameObject("DungeonRoom (" + count++ + ")");
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();

            Mesh mesh = new Mesh();

            List<Vector3> vertices = new List<Vector3>();
            List<Vector2> uvs = new List<Vector2>();
            List<Vector3> normals = new List<Vector3>();
            List<int[]> quads = new List<int[]>();
            List<List<int>> subMeshes = new List<List<int>>();
            for (int y = 0; y < room.y; y++)
            {
                for (int x = 0; x < room.x; x++)
                {
                    vertices.Add(new Vector3(x, 0, y));
                    uvs.Add(new Vector2(x, y));
                    normals.Add(Vector3.up);
                }
            }

            for (int y = 0; y < room.y - 1; y++)
            {
                for (int x = 0; x < room.x - 1; x++)
                {
                    quads.Add(new int[] { (y * room.x) + x, ((y + 1) * room.x) + x, (y * room.x) + x + 1, ((y + 1) * room.x) + x + 1 });
                }
            }

            mesh.SetVertices(vertices);
            mesh.SetUVs(0, uvs);
            mesh.SetNormals(normals);

            mesh.subMeshCount = 1 + dungeonType.dungeonFloorTile.variants.Count;
            foreach (int[] quad in quads)
            {
                
            }

            mesh.RecalculateBounds();
            MeshUtility.Optimize(mesh);
            meshFilter.mesh = mesh;

            gameObject.transform.position = new Vector3(room.xMin + (room.size.y / 2), room.yMin + (room.size.y / 2));

            roomGameObjects.Add(gameObject);
        }
    }

    private void PlaceGameObjects()
    {
        for (int x = minSize; x < maxSize; x++)
        {
            for (int y = minSize; y < maxSize; y++)
            {
                switch (map[x, y])
                {
                    case TileType.Floor:
                        //GameObject.Instantiate(wall, new Vector3Int(x, 0, y), Quaternion.identity);
                        break;
                    case TileType.Wall:
                        //GameObject.Instantiate(wall, new Vector3(x, 0.5f, y), Quaternion.identity);
                        break;
                }
            }
        }
    }
}
