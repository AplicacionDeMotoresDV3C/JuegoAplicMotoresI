using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrap : Trap
{
    [SerializeField] Damaging _damageComponent;

    void Awake()
    {
        _damageComponent.enabled = false;
    }

    protected override void Activate()
    {
        base.Activate();
        _damageComponent.enabled = true;
    }

    protected override void Reset(CheckpointStruct checpointData)
    {
        base.Reset(checpointData);
        _damageComponent.enabled = false;
    }
}
