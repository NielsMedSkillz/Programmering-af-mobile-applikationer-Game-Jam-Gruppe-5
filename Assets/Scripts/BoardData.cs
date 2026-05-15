using UnityEngine;

[CreateAssetMenu(menuName = "Board")]
public class BoardData : ScriptableObject
{
    public string[] sentences;
    public int correctSentence;
    public string wrongFeedback;
}
