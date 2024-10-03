using UnityEngine;
using UnityEngine.UI;

public class PlayerView
{
    private Image _healthBar = default;

    public PlayerView(Image healthBar)
    {
        _healthBar = healthBar;
    }

    public void UpdateHUD(float currentHealth)
    {
        _healthBar.fillAmount = currentHealth;
    }
}
