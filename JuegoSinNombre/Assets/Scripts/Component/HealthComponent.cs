using System;
using UnityEngine;


[Serializable]
public class HealthComponent
{
    [SerializeField]int _maxHealth;
    int _health;
    public bool isInvunerable = false;
    public event Action<DamageData> OnTakeDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action<CheckpointStruct> OnAssignHealth;


    //TPFinal - Rubio, Martín Omar
    public void StartingHealth()
    {
        _health = _maxHealth;
    }

    //TPFinal - Rubio, Martín Omar
    public void TakeDamage(DamageData data)
    {
        if (isInvunerable) return;

        isInvunerable = true;
        _health -= data.value;
        OnTakeDamage?.Invoke(data);

        if (_health <= 0)
        {
            Death();
        }
    }

    //TPFinal - Rubio, Martín Omar
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

    //TPFinal - Rubio, Martín Omar
    private void Death()
    {
        OnDeath?.Invoke();
    }

    //TPFinal - Gabriele Peruilh, Guido
    public void AssignHealth(CheckpointStruct data)
    {
        Debug.Log("Assign Health " + data.playerLife);
        _health = data.playerLife;
        if (_health > _maxHealth)
            _health = _maxHealth;

        OnAssignHealth?.Invoke(data);
    }

}
