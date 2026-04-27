using System.Linq;
using TMPro;
using UnityEngine;

public class BoardDisplay : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordContainer; // empty child on the board prefab

    public float spacingX = 0.05f;
    public float spacingY = 0.5f;
    public float maxLineWidth = 4f;

    public void Setup(BoardData data)
    {
        foreach (Transform child in wordContainer)
            Destroy(child.gameObject);

        string[] words = data.fullPrompt.Split(' ');

        float x = 0f;
        float y = 0f;

        foreach (string word in words)
        {
            GameObject obj = Instantiate(wordPrefab, wordContainer);

            bool isBad = data.badPhrases.Any(p =>
                word.ToLower().Contains(p.ToLower()));

            obj.GetComponent<WordObject>().Init(word, isBad);

            obj.transform.localPosition = new Vector3(x, y, 0f);

            // Use actual rendered width instead of guessing
            float wordWidth = obj.GetComponent<TMP_Text>().preferredWidth;
            x += wordWidth + spacingX;

            if (x > maxLineWidth)
            {
                x = 0f;
                y -= spacingY;
            }
        }
    }
}