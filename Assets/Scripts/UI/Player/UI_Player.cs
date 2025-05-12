using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UI_Player : MonoBehaviour
{
    private RectTransform rectTransform;

    public void Initialize()
    {
        rectTransform = GetComponent<RectTransform>();
        UpdateScale();
    }

    public float GetWidth() => rectTransform.sizeDelta.x;
    public float GetHeigth() => rectTransform.sizeDelta.y;
    public Vector3 GetPosition() => rectTransform.position;
    public Vector3 GetScale() => rectTransform.localScale;

    public void UpdateScale()
    {
        float percent = Resource.current.GetResourcePercent();

        transform.localScale = new Vector3(
            percent * 5,
            percent * 5,
            transform.localScale.z
        );
    }
}
