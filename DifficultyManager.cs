using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;

    public float gameSpeed;
    public float speedIncreaseRate;
    public float minSpawnTime;
    public float maxSpawnTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetEasy()
    {
        gameSpeed = 6f;
        speedIncreaseRate = 0.05f;
        minSpawnTime = 1.75f;
        maxSpawnTime = 3f;
    }

    public void SetMedium()
    {
        gameSpeed = 8f;
        speedIncreaseRate = 0.1f;
        minSpawnTime = 1.5f;
        maxSpawnTime = 2.5f;
    }

    public void SetHard()
    {
        gameSpeed = 12f;
        speedIncreaseRate = 0.2f;
        minSpawnTime = 0.9f;
        maxSpawnTime = 1.15f;
    }
}