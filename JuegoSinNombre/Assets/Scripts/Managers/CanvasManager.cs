using System;
using UnityEngine;
using UnityEngine.UI;


//basualdo sebastian
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
        _player.Health.OnAssignHealth += UpdateHealthBar;
        _player.OnStaminaCHange += UpdateStaminaBar;
        _player.GetComponentInChildren<InteractionDetector>().OnInteractuableChange += DisplayInteractiveCommand;
    }
    void UpdateHealthBar(DamageData data)
    {
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        _health = _player.Health.GetHealth();
        _maxHealth = _player.Health.GetMaxHeal();

        _health = Mathf.Clamp(_health, 0, _maxHealth);

        _lifeBar.fillAmount = _health / _maxHealth;
    }

    //Gabriele Peruilh, Guido
    void UpdateHealthBar(CheckpointStruct data)
    {
        UpdateHealthBar();
    }

    void UpdateStaminaBar()
    {
        _stamina = _player.Stamina;

        _maxStamina = _player.MaxStamina;

        _stamina = Mathf.Clamp(_stamina, 0, _maxStamina);

        _staminBar.fillAmount = _stamina / _maxStamina;
    }


    //Rubio, Martín Omar
    void DisplayInteractiveCommand(int elements)
    {
        _interactCommand.SetActive(elements >= 1);
    }

    void OnDestroy()
    {
        _player.Health.OnTakeDamage -= UpdateHealthBar;
        _player.Health.OnHeal -= UpdateHealthBar;
        _player.OnStaminaCHange -= UpdateStaminaBar;
        _player.GetComponentInChildren<InteractionDetector>().OnInteractuableChange -= DisplayInteractiveCommand;
    }
}
