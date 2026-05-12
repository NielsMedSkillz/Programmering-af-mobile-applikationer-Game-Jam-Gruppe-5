using System.Collections;
using UnityEngine;

public class ScreenTintManager : MonoBehaviour
{
    public static ScreenTintManager instance;
    public float flashDuration = 0.18f;
    public float overlayAlpha = 0.35f;

    private Color currentTint = Color.clear;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void Flash(Color color)
    {
        if (instance == null) return;
        StartCoroutine(FlashRoutine(color));
    }

    void OnGUI()
    {
        if (currentTint.a <= 0f) return;

        Color previousColor = GUI.color;
        GUI.color = currentTint;
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), Texture2D.whiteTexture);
        GUI.color = previousColor;
    }

    IEnumerator FlashRoutine(Color color)
    {
        currentTint = new Color(color.r, color.g, color.b, overlayAlpha);
        yield return new WaitForSeconds(flashDuration);
        currentTint = Color.clear;
    }
}
