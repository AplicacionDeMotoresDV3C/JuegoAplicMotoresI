using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CheckpointStruct
{
    public Vector3 checkpointPosition;
    public int playerLife;

    public CheckpointStruct(Vector3 checkpointPosition, int playerLife)
    {
        this.checkpointPosition = checkpointPosition;
        this.playerLife = playerLife;
    }
}
