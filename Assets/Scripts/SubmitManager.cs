using TMPro;
using UnityEngine;

public class SubmitManager : MonoBehaviour
{
    public int correctIndex;
    public int points;
    public TextMeshProUGUI pointText;

    public void OnSubmit()
    {
        PromptClickDetector[] prompts = FindObjectsByType<PromptClickDetector>(FindObjectsSortMode.None);

        bool correctSelected = false;
        bool wrongSelected = false;

        foreach (PromptClickDetector prompt in prompts)
        {
            if (prompt.selected)
            {
                if (prompt.index == correctIndex)
                    correctSelected = true;
                else wrongSelected = true;
                    wrongSelected = true;
            }
        }

        if (correctSelected && !wrongSelected)
        {
            points++;
            Debug.Log("Correct!");
            pointText.text = points.ToString();
        }

        else
            Debug.Log("Fail!");
    }
}