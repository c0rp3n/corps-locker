using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType : uint
{
    None = 0,
    Floor = 1 << 0,
    Entrance = 1 << 1,
    Wall = 1 << 2,
}

public enum TileAdjacentType : uint
{
    Default = 1 << 0,
    Solus = 1 << 1,
    Above = 1 << 2,
    Below = 1 << 3,
    Left = 1 << 4,
    Right = 1 << 5,
    AboveLeft = 1 << 6,
    AboveRight = 1 << 7,
    BelowLeft = 1 << 8,
    BelowRight = 1 << 9,
    All = Above | Below | Left | Right | AboveLeft | AboveRight | BelowLeft | BelowRight,
}
