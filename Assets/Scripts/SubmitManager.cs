using TMPro;
using UnityEngine;
using System.Collections;

public class SubmitManager : MonoBehaviour
{
    public int correctIndex;
    public int points;
    public TextMeshProUGUI pointText;

    public GameObject correctText;

    public GameObject incorrectText;

    public void OnSubmit()
    {
        PromptClickDetector[] prompts = FindObjectsByType<PromptClickDetector>(FindObjectsSortMode.None);

        bool correctSelected = false;
        bool wrongSelected = false;

        FindFirstObjectByType<BoardSpawner>().decreaseTime = false;
        FindFirstObjectByType<BoardSpawner>().visualTimer.color = Color.green;

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
            StartCoroutine(correctTextAnim());
        }

        else
        {
            Debug.Log("Fail!");
            points--;
            pointText.text = points.ToString();
            StartCoroutine(incorrectTextAnim());
        }

    }
    IEnumerator correctTextAnim()
        {
            correctText.SetActive(true);
            yield return new WaitForSeconds(2f);
            correctText.SetActive(false);
        }

    IEnumerator incorrectTextAnim()
        {
            incorrectText.SetActive(true);
            yield return new WaitForSeconds(2f);
            incorrectText.SetActive(false);
        }
}