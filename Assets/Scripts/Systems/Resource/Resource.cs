using UnityEngine;

public class Resource : MonoBehaviour 
{
    public static Resource current;
    
    [SerializeField] private float maxResource;
    private float currentResource;

    public void Initialize()
    {
        current = this;

        currentResource = maxResource;
    }

    public void Consume(float amount) => currentResource = Mathf.Max(currentResource - amount, 0);
    
    public float GetMaxResource() => maxResource;
    public float GetCurrentResource() => currentResource;
    public bool HasResource() => currentResource > 0;
    public float GetResourcePercent() => currentResource / maxResource;
}