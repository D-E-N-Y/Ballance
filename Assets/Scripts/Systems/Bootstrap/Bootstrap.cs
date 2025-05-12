using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Resource resource;
    [SerializeField] private Result result;
    [SerializeField] private SetPlayerSpawner playerSpawner;
    [SerializeField] private SpawnObstacles obstacleSpawner;
    [SerializeField] private Goal goalSpawner;
    
    private void Start()
    {
        resource.Initialize();
        result.Initialize();

        obstacleSpawner.Initialize();
        playerSpawner.Initialize();
        goalSpawner.Initialize();

        Time.timeScale = 1;
    }
}
