using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText;
    private GameManager gameManager;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();

        // ✅ Updated for Unity 2023+ (avoids deprecation warning)
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if (gameManager != null)
                gameManager.GameOver();
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "Health: " + currentHealth;
    }
}
