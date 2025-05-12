using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Material normal, mutant;
    [SerializeField, Range(1f, 10f)] private float speed;
    
    public EPlayerType type { get; private set; }
    
    public bool isShooting { get; private set; }
    private Coroutine shoot;

    [SerializeField] private Boom boom;

    private MeshRenderer _renderer;

    public void Initialize(Vector3 position, Quaternion rotation, float caliber)
    {
        transform.position = position;
        transform.rotation = rotation;
        transform.localScale = new Vector3(
            caliber / 7,
            caliber / 7,
            caliber / 7
        );

        _renderer = GetComponent<MeshRenderer>();
        if(Random.Range(1, 10) <= 2)
        {
            type = EPlayerType.Mutant;
            _renderer.material = mutant;
        }
        else
        {
            type = EPlayerType.Normal;
            _renderer.material = normal;
        }
        _renderer.UpdateGIMaterials();
          
        gameObject.SetActive(true);
        
        shoot = StartCoroutine(nameof(Shoot));
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        
        while(true)
        {
            transform.position += transform.forward.normalized * speed * Time.deltaTime;

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacle))
        {
            boom.Initialize(
                type, 
                _renderer.material, 
                transform.position, 
                transform.localScale.x
            );
            
            transform.position = new Vector3(0, 100, 0);

            StopCoroutine(shoot);
            isShooting = false;

            if(!Resource.current.HasResource())
            {
                Result.current.Lose();
            }
        }
    }
}
