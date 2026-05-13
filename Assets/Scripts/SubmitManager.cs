using TMPro;
using UnityEngine;
using System.Linq;

public class SubmitManager : MonoBehaviour
{
    public int[] correctIndexes;
    public int points;
    public TextMeshProUGUI pointText;

    public void OnSubmit()
    {
        PromptClickDetector[] prompts = FindObjectsByType<PromptClickDetector>(FindObjectsSortMode.None);

        bool failed = false;

        foreach (PromptClickDetector prompt in prompts)
        {
            bool shouldBeSelected = correctIndexes.Contains(prompt.index);

            if (prompt.selected != shouldBeSelected)
            {
                failed = true;
                break;
            }
        }

        if (!failed)
        {
            points++;
            Debug.Log("Correct!");
        }
        else
        {
            points--;
            Debug.Log("Fail!");
        }

        pointText.text = points.ToString();

    }
}