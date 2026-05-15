using UnityEngine;
using TMPro;

public class PromptSpawner : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform textParent;
    public SubmitManager submitManager;

    public void SpawnPrompt(BoardData data)
    {
        submitManager.correctIndex = data.correctSentence;
        submitManager.wrongFeedback = data.wrongFeedback;

        for (int i = 0; i < data.sentences.Length; i++)
        {
            GameObject txt = Instantiate(textPrefab, textParent);

            txt.GetComponent<TMP_Text>().text = data.sentences[i];

            PromptClickDetector option = txt.GetComponent<PromptClickDetector>();
            option.index = i;
        }
    }
}