﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemies : MonoBehaviour
{
    Object_Pool pool;
    GameObject player;
    public float spawnRatePerSecond;

    void Start()
    {
        player = GameObject.Find("Player Ship");
        pool = Object_Pool.Instance;
        InvokeRepeating("SpawnEnemy", 0, 1f/spawnRatePerSecond);
    }

    void Update()
    {
        
    }

    void SpawnEnemy() {
        Vector3 randomPlace = Random.insideUnitCircle;
        randomPlace.Normalize();
        randomPlace *= 25f;
        Vector3 placeToSpawn = new Vector3(randomPlace.x, 0.5f, randomPlace.y);
        pool.SpawnFromPool("Enemy", player.transform.TransformPoint(placeToSpawn), Quaternion.identity);
    }
}
