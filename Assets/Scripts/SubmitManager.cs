using TMPro;
using UnityEngine;
using System.Collections;

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
            AudioManager.instance.PlaySound("Right");
            if (ScreenTintManager.instance != null) ScreenTintManager.instance.Flash(Color.green);
        }

        else
        {
            Debug.Log("Fail!");
            points--;
            pointText.text = points.ToString();
            if (HealthManager.instance != null) HealthManager.instance.DecreaseHealth();
            AudioManager.instance.PlaySound("Wrong");
            if (ScreenTintManager.instance != null) ScreenTintManager.instance.Flash(Color.red);
        }

    }
}