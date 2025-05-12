using UnityEngine;

public class GoalRadar : MonoBehaviour 
{
    private Goal goal;

    public void Initialize(Goal goal)
    {
        this.goal = goal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            goal.Open();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            goal.Close();
        }
    }
}