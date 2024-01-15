using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManger : MonoBehaviour
{
    public static SpawnManger Instance;

    private Spawnpoint[] spawnpoints;

    private void Awake()
    {
        Instance = this;
        spawnpoints = GetComponentsInChildren<Spawnpoint>();
    }

    public Transform GetSpawnpoint()
    {
        return spawnpoints[Random.Range(0, spawnpoints.Length)].transform;
    }
}
