using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GoalRadar radar;
    [SerializeField] private Material open, close;
    private MeshRenderer meshRenderer;

    public void Initialize()
    {
        radar.Initialize(this);
        
        meshRenderer = GetComponent<MeshRenderer>();
        Close();
    }
    
    public void Open()
    {
        meshRenderer.material = open;
        meshRenderer.UpdateGIMaterials();
    }

    public void Close()
    {
        meshRenderer.material = close;
        meshRenderer.UpdateGIMaterials();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            Result.current.Win();
        }
    }
}
