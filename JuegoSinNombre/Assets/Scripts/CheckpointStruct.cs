using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CheckpointStruct
{
    public Vector3 checkpointPosition;

    public CheckpointStruct(Vector3 checkpointPosition)
    {
        this.checkpointPosition = checkpointPosition;
    }
}
