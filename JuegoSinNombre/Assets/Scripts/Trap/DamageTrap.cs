using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrap : Trap
{
    [SerializeField] Damaging _damageComponent;

    void Start()
    {
        _damageComponent.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Activate();
    }

    protected override void Activate()
    {
        base.Activate();
        _damageComponent.enabled = true;
    }
}
