using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Result : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ui_result;

    public void Initialize(string result)
    {
        ui_result.text = result;
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
