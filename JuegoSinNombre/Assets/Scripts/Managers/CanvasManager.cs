using System;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    [SerializeField] Image _lifeBar;
    [SerializeField] Image _staminBar;
    [SerializeField] GameObject _interactCommand;
    [SerializeField] Player _player;
    float _health;
    float _stamina;
    float _maxStamina;
    float _maxHealth;

private void Start()
    {
        _player.Health.OnTakeDamage += UpdateHealthBar;
        _player.Health.OnHeal += UpdateHealthBar;
        _player.OnStaminaCHange += UpdateStaminaBar;
        _player.GetComponentInChildren<InteractionDetector>().OnInteractuableChange += DisplayInteractiveCommand;
    }
    void UpdateHealthBar(DamageData data)
    {
        _health = _player.Health.GetHealth();
        _maxHealth = _player.Health.GetMaxHeal();

        _health = Mathf.Clamp(_health, 0, _maxHealth);

        _lifeBar.fillAmount = _health / _maxHealth;
    }
    void UpdateHealthBar()
    {
        _health = _player.Health.GetHealth();
        _maxHealth = _player.Health.GetMaxHeal();

        _health = Mathf.Clamp(_health, 0, _maxHealth);

        _lifeBar.fillAmount = _health / _maxHealth;
    }
    void UpdateStaminaBar()
    {
        _stamina = _player.Stamina;

        _maxStamina = _player.MaxStamina;

        _stamina = Mathf.Clamp(_stamina, 0, _maxStamina);

        _staminBar.fillAmount = _stamina / _maxStamina;
    }

    void DisplayInteractiveCommand(int elements)
    {
        _interactCommand.SetActive(elements >= 1);
    }
}
