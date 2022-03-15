using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // == Public Fields ==
    public GameObject[] spawnerPositions;
    public GameObject spawnerPrefab;

    // == Private Fields ==
    private float spawnTime;

    void Start()
    {
        // Set spawn time
        spawnTime = GameManager.resetSpawnTime;
    }

    void Update()
    {
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        // If spawn time has reached 0 or less
        if (spawnTime <= 0)
        {
            // Set a random spawn point
            int randomSpawnPoint = Random.Range(0, spawnerPositions.Length);

            // Spawn an obstacle at that random position
            Instantiate(spawnerPrefab, spawnerPositions[randomSpawnPoint].transform.position, transform.rotation);

            // Set the spawn time back to the starting time
            spawnTime = GameManager.resetSpawnTime;
        }
        else // Otherwise
        {
            // Decrease the spawn time
            spawnTime -= Time.deltaTime;
        }
    }
}
