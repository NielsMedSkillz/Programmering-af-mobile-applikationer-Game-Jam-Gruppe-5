using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public int health = 3;
    public TextMeshProUGUI healthText;

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

        UpdateHealthDisplay();
    }

    public void DecreaseHealth()
    {
        health--;
        UpdateHealthDisplay();

        if (health <= 0)
        {
            ReloadScene();
        }
    }

    void UpdateHealthDisplay()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + health.ToString();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
