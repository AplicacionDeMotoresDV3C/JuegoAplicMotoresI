using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HealthComponent
{
    [SerializeField]int _maxHealth;
    int _health;
    public Action OnTakeDamage;
    public Action OnHeal;
    public Action OnDeath;

    public void SetHealth()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
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

    private void Death()
    {
        OnDeath?.Invoke();
    }

}
