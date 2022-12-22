using UnityEngine;

//Rubio, Martín Omar
public struct DamageData
{
    public int value;
    public DamageSource source;
    public Vector3 position;

    public DamageData(int value, DamageSource source, Vector3 position)
    {
        this.value = value;
        this.source = source;
        this.position = position;
    }
}

public enum DamageSource
{
    Player,
    Enemy,
    Trap
}
