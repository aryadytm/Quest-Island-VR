using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerobject : MonoBehaviour
{
    public GameObject objectToSpawn; 
    public GameObject hintobject;
    public Transform spawnPoint; 
    public Vector3 spawnAreaSize = new Vector3(5f, 0f, 5f); // Size of the area around the spawn point where objects can randomly appear
    public int spawnCount = 50; 
    public float SpawnTime = 5f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, SpawnTime);
    }

    private void SpawnObject()
    {
        if (spawnCount > 0)
        {
            Vector3 randomPosition = new Vector3(
                UnityEngine.Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                UnityEngine.Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                UnityEngine.Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );
            Instantiate(objectToSpawn, spawnPoint.position + randomPosition, spawnPoint.rotation);
            spawnCount--; 
        }
        else
        {
            CancelInvoke("SpawnObject");
        }
    }

}
