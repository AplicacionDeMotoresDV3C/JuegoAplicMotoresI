using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    public Image _lifeBar;
    [SerializeField] Player _player;
    float _health;
    float _maxHealth;
    private void Start()
    {
        _player.Health.OnTakeDamage += UpdateHealthBar;
    }
    void UpdateHealthBar(DamageData data)
    {
        _health = _player.Health.GetHealth();
        _maxHealth = _player.Health.GetMaxHeal();

        _health = Mathf.Clamp(_health, 0, 100);

        _lifeBar.fillAmount = _health / 100;
    }
}
