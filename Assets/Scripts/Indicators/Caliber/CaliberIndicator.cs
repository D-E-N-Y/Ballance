using System;
using System.Collections;
using UnityEngine;

public class CaliberIndicator : MonoBehaviour
{
    public float caliber { get; private set; }
    
    private UI_Player ui_player;
    private Coroutine choiceCaliber;
    
    private RectTransform ui_indicator;

    [SerializeField, Range(0.1f, 10f)] private float speed;
    [SerializeField, Range(1f, 10f)] private float minCaliber;

    public void Initialize(UI_Player ui_player)
    {
        this.ui_player = ui_player;

        ui_indicator = GetComponent<RectTransform>();
    }

    public void StartChoiceCaliber()
    {
        gameObject.SetActive(true);
        choiceCaliber = StartCoroutine(nameof(ChoiceCaliber));
    }

    private IEnumerator ChoiceCaliber()
    {
        float time = 0f;
        
        while(true)
        {
            time += Time.deltaTime;
            float t = Mathf.PingPong(time * speed, 1f);
            
            caliber = Mathf.Lerp(minCaliber, ui_player.GetScale().x * 6f, t);
            
            ui_indicator.sizeDelta = new Vector2(
                caliber,
                ui_indicator.sizeDelta.y
            );

            yield return null;
        }
    }

    public void StopChoiceCaliber()
    {
        StopCoroutine(choiceCaliber);
        gameObject.SetActive(false);
    }
}
