using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HealthComponent
{
    [SerializeField]int _maxHealth;
    int _health;
    public bool isInvunerable = false;
    public event Action OnTakeDamage;
    public event Action OnHeal;
    public event Action OnDeath;

    public void SetHealth()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvunerable) return;

        isInvunerable = true;
        _health -= damage;
        OnTakeDamage?.Invoke();

        if (_health <= 0)
        {
            Death();
        }
    }

    public void Heal(int healValue)
    {
        _health += healValue;

        if (_health > _maxHealth)
            _health = _maxHealth;

        OnHeal?.Invoke();
    }
    public int GetMaxHeal()
    {
        return _maxHealth;
    }
    public int GetHealth()
    {
        return _health;
    }
    private void Death()
    {
        OnDeath?.Invoke();
    }

}
