using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPatrol : Enemy
{
    protected abstract void Patrol();
    protected abstract void WaitPatrol();
}
