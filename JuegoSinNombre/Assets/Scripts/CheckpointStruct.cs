using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CheckpointStruct
{
    public Vector3 checkpointPosition;
    public float bossLife;


    public CheckpointStruct(Vector3 checkpointPosition, float bossLife)
    {
        this.checkpointPosition = checkpointPosition;
        this.bossLife = bossLife;
    }
}
