using UnityEngine;
using TMPro;

public class PromptSpawner : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform textParent;

    public void SpawnPrompt(BoardData data)
    {
        for (int i = 0; i < data.sentances.Length; i++)
        {
            GameObject txt = Instantiate(textPrefab, textParent);

            txt.GetComponent<TMP_Text>().text = data.sentances[i];

            txt.GetComponent<PromptClickDetector>().index = i;
        }
    }
}