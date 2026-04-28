using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PromptClickDetector : MonoBehaviour, IPointerClickHandler
{
    public int index;

    private TMP_Text text;
    private bool selected = false;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
        text.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selected = !selected;

        if (selected)
            text.color = Color.red;
        else
            text.color = Color.white;
    }
}