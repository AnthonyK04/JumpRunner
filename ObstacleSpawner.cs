using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float minSpawnTime = 1.2f;
    public float maxSpawnTime = 3f;

    void Start()
    {
        if (DifficultyManager.Instance != null)
        {
            minSpawnTime = DifficultyManager.Instance.minSpawnTime;
            maxSpawnTime = DifficultyManager.Instance.maxSpawnTime;
        }

        Invoke(nameof(SpawnObstacle), Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);
        //selects random obstacle prefab and spawns it
        GameObject prefab = obstaclePrefabs[index];

        // use spawner X but keep prefabs' Y position
        Vector3 spawnPos = new Vector3(transform.position.x, prefab.transform.position.y, 0);

        Instantiate(prefab, spawnPos, Quaternion.identity);
        Invoke(nameof(SpawnObstacle), Random.Range(minSpawnTime, maxSpawnTime));
    }
}