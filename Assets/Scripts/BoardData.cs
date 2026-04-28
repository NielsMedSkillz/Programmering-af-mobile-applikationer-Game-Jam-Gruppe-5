using UnityEngine;

[CreateAssetMenu(menuName = "Board")]
public class BoardData : ScriptableObject
{
    public string[] sentances;
    public int correctSentance;
}