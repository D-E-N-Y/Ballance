using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private Player player;
    
    private UI_Player ui_player;
    private CaliberIndicator ui_caliber;

    private bool isShooting;

    public void Initialize(UI_Player ui_player, CaliberIndicator ui_caliber)
    {
        this.ui_player = ui_player;
        this.ui_caliber = ui_caliber;
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            if(!isShooting && !player.isShooting)
            {
                isShooting = true;
                ui_caliber.StartChoiceCaliber();
            }
        }
        else if(Input.touchCount == 0 && isShooting)
        {
            isShooting = false;
            ui_caliber.StopChoiceCaliber();

            Shoot(ui_caliber.caliber);
        }
    }

    private void Shoot(float caliber)
    {
        Debug.Log($"Shoot caliber : {caliber}");

        player.Initialize(transform.position, transform.rotation, caliber);

        Resource.current.Consume(caliber);
        ui_player.UpdateScale();
    }
}
