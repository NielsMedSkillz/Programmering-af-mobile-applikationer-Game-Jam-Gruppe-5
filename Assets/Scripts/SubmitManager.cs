using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubmitManager : MonoBehaviour
{
    public int correctIndex;
    public int points;
    public TextMeshProUGUI pointText;
    public Button submitButton;

    public BoardSpawner boardSpawner;

    public void OnSubmit()
    {

        submitButton.interactable = false;
        Invoke(nameof(EnableButton), 2f);

        PromptClickDetector[] prompts = FindObjectsByType<PromptClickDetector>(FindObjectsSortMode.None);

        bool correctSelected = false;
        bool wrongSelected = false;
        bool anythingSelected = false;

        foreach (PromptClickDetector prompt in prompts)
        {
            if (prompt.selected)
            {
                anythingSelected = true;

                if (prompt.index == correctIndex)
                {
                    Debug.Log("donnneone");
                    correctSelected = true;
                }

                else wrongSelected = true;
            }
        }

        if (!anythingSelected)
        {
            Debug.Log("Nothing selected!");
            return;
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

        boardSpawner.resumeBoard();
        boardSpawner.board = null;
        boardSpawner.SpawnNext();


    }
    void EnableButton()
    {
        submitButton.interactable = true;
    }
}