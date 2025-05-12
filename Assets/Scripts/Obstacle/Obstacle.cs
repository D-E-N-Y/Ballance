using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private MeshRenderer _renderer;
    private EPlayerType infectionType;

    [SerializeField] private Boom boom;

    public void Initialize()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void Infection(EPlayerType type, Material material)
    {
        infectionType = type;

        _renderer.material = material;
        _renderer.UpdateGIMaterials();

        StartCoroutine(nameof(Live));
    }

    private IEnumerator Live()
    {
        yield return new WaitForSeconds(1.5f);
        
        if(infectionType == EPlayerType.Mutant)
        {
            boom = Instantiate(boom, transform.position, Quaternion.identity);
            boom.Initialize(
                EPlayerType.Normal, 
                _renderer.material, 
                transform.position, 
                1.5f
            );
        }
        
        gameObject.SetActive(false);
    }
}
