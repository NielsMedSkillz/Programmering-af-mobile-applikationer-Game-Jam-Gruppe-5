using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PromptClickDetector : MonoBehaviour, IPointerClickHandler
{
    public int index;
    public bool selected = false;

    TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
        text.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selected = !selected;
        text.color = selected ? Color.red : Color.white;
    }
}