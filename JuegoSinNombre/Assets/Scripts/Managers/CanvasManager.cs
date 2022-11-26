using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    public Image _lifeBar;
    [SerializeField] Image _staminBar;
    [SerializeField] Player _player;
    float _health;
    float _stamina;
    float _maxStamina;
    float _maxHealth;
    private void Start()
    {
        _player.Health.OnTakeDamage += UpdateHealthBar;
       _player.OnStaminaCHange += UpdateStaminaBar;
    }
    void UpdateHealthBar()
    {
        _health = _player.Health.GetHealth();
        _maxHealth = _player.Health.GetMaxHeal();

        _health = Mathf.Clamp(_health, 0, 100);

        _lifeBar.fillAmount = _health / 100;
    }
    void UpdateStaminaBar()
    {
        _stamina = _player.Stamina;

        _maxStamina = _player.MaxStamina;

        _stamina = Mathf.Clamp(_stamina, 0, 10);

        _staminBar.fillAmount = _stamina / 10;
    }
}
