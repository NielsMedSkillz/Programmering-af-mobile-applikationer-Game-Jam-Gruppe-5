using UnityEngine;
using TMPro;

public class BoardDisplay : MonoBehaviour
{
    TMP_Text promptText;

    void Awake()
    {
        promptText = GetComponent<TMP_Text>();
    }

    public void Setup(BoardData data)
    {
        promptText.text = data.fullPrompt;
    }
}