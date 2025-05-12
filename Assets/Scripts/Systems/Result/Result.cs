using UnityEngine;

public class Result : MonoBehaviour
{
    public static Result current;

    [SerializeField] private UI_Result ui_result;

    public void Initialize()
    {
        current = this;
    }

    public void Lose()
    {
        ui_result.Initialize("Lose");
        Time.timeScale = 0;
    }

    public void Win()
    {
        ui_result.Initialize("Win");
        Time.timeScale = 0;
    }
}
