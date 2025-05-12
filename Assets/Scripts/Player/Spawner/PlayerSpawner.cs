using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform goal;
    [SerializeField] private CaliberIndicator ui_caliber;
    [SerializeField] private ShootPlayer shoot;

    public void Initialize(UI_Player ui_player)
    {
        RotateToGoal();
        
        ui_caliber.Initialize(ui_player);
        shoot.Initialize(ui_player, ui_caliber);
    }
    
    public void RotateToGoal()
    {
        Vector3 _position = new Vector3(
            goal.position.x,
            0f,
            goal.position.z
        );

        Transform _transform = goal;
        _transform.position = _position;
        
        transform.LookAt(_transform);
    }
}
