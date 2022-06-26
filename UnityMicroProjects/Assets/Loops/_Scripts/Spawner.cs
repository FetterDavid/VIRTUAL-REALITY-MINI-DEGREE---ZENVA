using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnCount = 5;
    public float spawnOffset = 1.5f; 

    void Start()
    {
        SpawnEnemy(); 
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Cannot spawn enemies! Prefab is missing.");
        }
        else
        {
            for (int i = 0; i < spawnCount; i++)
            {
                float xPos = i * spawnOffset;
                Vector3 spawnPos = new Vector3 (xPos, 0, 0);

                Instantiate(enemyPrefab,spawnPos, Quaternion.identity);
            }
        }
    }
}
