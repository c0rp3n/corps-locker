using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

class LevelManager : MonoBehaviour
{
    void Start()
    {
        Dungeon dungeon = new Dungeon(0);
        dungeon.Generate();
    }

    void FixedUpdate()
    {

    }

    void Update()
    {

    }
}
