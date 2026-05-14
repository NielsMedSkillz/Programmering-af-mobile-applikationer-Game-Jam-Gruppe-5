using TMPro;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;

public class SubmitManager : MonoBehaviour
{
    public int correctIndex;
    public int points;
    public TextMeshProUGUI pointText;
    public bool submitLocked = true; //Change
    public BoardSpawner boardSpawner; //Change

    public void OnSubmit()
    {
        if (submitLocked) return; //Change

        submitLocked = true; //Change

        PromptClickDetector[] prompts = FindObjectsByType<PromptClickDetector>(FindObjectsSortMode.None);

        bool correctSelected = false;
        bool wrongSelected = false;

        foreach (PromptClickDetector prompt in prompts)
        {
            if (prompt.selected)
            {
                if (prompt.index == correctIndex)
                {
                    Debug.Log("donnneone");
                    correctSelected = true;
                }

                else wrongSelected = true;
            }
        }

        if (correctSelected && !wrongSelected)
        {
            points++;
            Debug.Log("Correct!");
            pointText.text = points.ToString();
        }

        else
        {
            Debug.Log("Fail!");
            points--;
            pointText.text = points.ToString();
        }

        boardSpawner.resumeBoard(); //Change

    }

}