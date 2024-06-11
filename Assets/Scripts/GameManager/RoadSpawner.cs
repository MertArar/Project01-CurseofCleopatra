using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject[] roadPrefabs;
    public int initialRoadCount = 5;
    public float roadLength = 100f;
    public float spawnDistance = 200f;

    private Queue<GameObject> activeRoads = new Queue<GameObject>();
    private float nextSpawnPosition = 0f;

    void Start()
    {
        for (int i = 0; i < initialRoadCount; i++)
        {
            SpawnRandomRoad();
        }
    }

    void Update()
    {
        if (player.position.z > nextSpawnPosition - spawnDistance)
        {
            SpawnRandomRoad();
            RemoveOldRoad();
        }
    }

    void SpawnRandomRoad()
    {
        GameObject road = Instantiate(roadPrefabs[Random.Range(0, roadPrefabs.Length)], new Vector3(0, 0, nextSpawnPosition), Quaternion.identity);
        activeRoads.Enqueue(road);
        nextSpawnPosition += roadLength;
    }

    void RemoveOldRoad()
    {
        if (activeRoads.Count > initialRoadCount)
        {
            GameObject oldRoad = activeRoads.Dequeue();
            Destroy(oldRoad);
        }
    }
}