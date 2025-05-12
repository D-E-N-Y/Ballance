using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private Obstacle obstacle;
    [SerializeField, Range(1, 1000)] int spawnCount; 
    [SerializeField, Range(0.1f, 10f)] float density;
    private BoxCollider spawnArea;

    private List<Obstacle> obstacles;

    public void Initialize()
    {
        spawnArea = gameObject.GetComponent<BoxCollider>();
        obstacles = new List<Obstacle>();

        for (int i = 0; i < spawnCount; i++)
        {
            int attempts = 0;

            while (attempts < 100)
            {
                attempts++;
                Vector3 randomPos = GetRandomPositionInCollider(spawnArea);
                
                if(obstacles.Any(x => Vector3.Distance(x.transform.position, randomPos) < density))
                {
                    continue;
                }
                
                Obstacle _obstacle = Instantiate(obstacle, randomPos, Quaternion.identity);
                _obstacle.transform.SetParent(transform);
                _obstacle.Initialize();
                obstacles.Add(_obstacle);

                break;
            }
            
        }
    }

    private Vector3 GetRandomPositionInCollider(BoxCollider box)
    {
        Vector3 center = box.center + box.transform.position;
        Vector3 size = box.size * 0.5f;

        float x = Random.Range(-size.x, size.x);
        float y = 0;
        float z = Random.Range(-size.z, size.z);

        return center + box.transform.rotation * new Vector3(x, y, z);
    }
}
