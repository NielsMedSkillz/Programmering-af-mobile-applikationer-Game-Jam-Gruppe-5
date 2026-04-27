using UnityEngine;
using TMPro;

public class WordObject : MonoBehaviour
{
    public bool isBadWord = false;
    TMP_Text label;

    void Awake() => label = GetComponent<TMP_Text>();

    public void Init(string word, bool bad)
    {
        label.text = word;
        isBadWord = bad;

        // Resize collider to fit the word
        GetComponent<BoxCollider2D>().size =
            new Vector2(label.preferredWidth, label.preferredHeight);
    }

    public void Erase()
    {
        gameObject.SetActive(false);
    }
}