using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("FinalScore", 0).ToString();
    }
}
