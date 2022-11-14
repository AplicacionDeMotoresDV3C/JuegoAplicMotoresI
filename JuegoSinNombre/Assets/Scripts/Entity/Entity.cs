using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] HealthComponent _health;
    public HealthComponent Health { get; }

    [SerializeField] protected float speed;

    // Start is called before the first frame update
    void Awake()
    {
        _health.SetHealth();
    }

    protected abstract void Attack();
    protected abstract void Move(Vector3 direction);
   
}
