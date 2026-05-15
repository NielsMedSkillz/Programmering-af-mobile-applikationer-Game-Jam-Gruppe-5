using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubmitManager : MonoBehaviour
{
    public int correctIndex;
    public string wrongFeedback;

    public int points;
    public int correctCount;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI feedbackText;

    public BoardSpawner boardSpawner;
    public float feedbackDuration = 2f;

    bool isSubmitting = false;

    public void OnSubmit()
    {
        if (isSubmitting || !boardSpawner.IsBoardStopped()) return;
        isSubmitting = true;
        StartCoroutine(HandleSubmit());
    }

    IEnumerator HandleSubmit()
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
                else
                    wrongSelected = true;
            }
        }

        if (correctSelected && !wrongSelected)
        {
            points++;
            correctCount++;
            pointText.text = points.ToString();
        }
        else
        {
            points--;
            pointText.text = points.ToString();
            feedbackText.text = wrongFeedback;
            feedbackText.gameObject.SetActive(true);
            feedbackText.transform.SetAsLastSibling();
            yield return new WaitForSeconds(feedbackDuration);
            feedbackText.gameObject.SetActive(false);

            if (points <= -5)
            {
                PlayerPrefs.SetInt("FinalScore", correctCount);
                SceneManager.LoadScene("LossScreen");
                yield break;
            }
        }

        boardSpawner.AllowResume();
        boardSpawner.resumeBoard();
        isSubmitting = false;
    }
}
