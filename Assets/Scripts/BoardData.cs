using UnityEngine;

[CreateAssetMenu(menuName = "Board")]
public class BoardData : ScriptableObject
{
    [TextArea(5, 10)]
    public string fullPrompt;

    public string[] badPhrases;
}