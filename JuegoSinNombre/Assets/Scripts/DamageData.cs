using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DamageData
{
    public int value;
    public string target;
    public Vector3 position;

    public DamageData(int value, string target, Vector3 position)
    {
        this.value = value;
        this.target = target;
        this.position = position;
    }
}
