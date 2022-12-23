using UnityEngine;


//TPFinal - Rubio, Mart�n Omar
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
