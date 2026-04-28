using UnityEngine;

public class SubmitManager : MonoBehaviour
{
    public int correctIndex;

    public void OnSubmit()
    {
        Debug.Log("gwhetjjf");
        PromptClickDetector[] prompts = FindObjectsByType<PromptClickDetector>(FindObjectsSortMode.None);

        bool correctSelected = false;
        bool wrongSelected = false;

        foreach (PromptClickDetector prompt in prompts)
        {
            if (prompt.selected)
            {
                if (prompt.index == correctIndex)
                    correctSelected = true;
                else
                    wrongSelected = true;
            }
        }

        if (correctSelected && !wrongSelected)
            Debug.Log("Correct!");
        else
            Debug.Log("Fail!");
    }
}