using UnityEngine;

public class SetPlayerSpawner : MonoBehaviour
{
    [SerializeField] private UI_Player ui_player;
    [SerializeField] private PlayerSpawner spawnPlayers;
    [SerializeField] private LayerMask layerMask;
    private Camera _camera;

    public void Initialize()
    {
        _camera = Camera.main;

        ui_player.Initialize();

        Vector3 playerPos = new Vector3(
            ui_player.GetPosition().x + ui_player.GetWidth() * 2,
            ui_player.GetPosition().y + ui_player.GetHeigth() * 2,
            ui_player.GetPosition().z);

        RaycastHit hit;
        if(Physics.Raycast(_camera.ScreenPointToRay(playerPos), out hit, Mathf.Infinity, layerMask))
        {
            spawnPlayers.gameObject.transform.position = hit.point;
            spawnPlayers.Initialize(ui_player);
        }
    }
}
