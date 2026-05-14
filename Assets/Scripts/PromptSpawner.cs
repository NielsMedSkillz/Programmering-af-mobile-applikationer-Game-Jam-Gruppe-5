using UnityEngine;
using TMPro;

public class PromptSpawner : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform textParent;
    public SubmitManager submitManager;

    public void SpawnPrompt(BoardData data)
    {
        submitManager.correctIndex = data.correctSentance;

        for (int i = 0; i < data.sentances.Length; i++)
        {
            GameObject txt = Instantiate(textPrefab, textParent);

            txt.GetComponent<TMP_Text>().text = data.sentances[i];

            PromptClickDetector option = txt.GetComponent<PromptClickDetector>();
            option.index = i;
        }
    }
}