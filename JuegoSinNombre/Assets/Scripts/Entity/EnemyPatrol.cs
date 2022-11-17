using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPatrol : Enemy
{
    [SerializeField] protected Transform[] waypoints;
    [SerializeField] protected float waytime;
    protected abstract void Patrol();
    protected abstract void WaitPatrol();
}
