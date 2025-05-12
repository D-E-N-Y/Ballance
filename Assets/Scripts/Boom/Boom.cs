using System.Collections;
using UnityEngine;

public class Boom : MonoBehaviour 
{
    private EPlayerType infectionType;
    private Material infectionMaterial;

    [SerializeField] private SphereCollider _collider;

    private Coroutine boomLive;

    public void Initialize(EPlayerType type, Material material, Vector3 position, float radius)
    {
        infectionType = type;
        infectionMaterial = material;
        
        transform.position = position;

        _collider.radius = radius;

        gameObject.SetActive(true);
        StartCoroutine(nameof(BoomLive));
    }

    private IEnumerator BoomLive()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacle))
        {
            obstacle.Infection(infectionType, infectionMaterial);
        }
    }
}