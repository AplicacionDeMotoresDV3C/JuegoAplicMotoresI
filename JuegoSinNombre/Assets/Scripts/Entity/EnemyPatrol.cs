using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPatrol : Enemy
{
    [SerializeField] protected float _waitTime;
    [SerializeField] protected Transform _wayPoints;

    protected abstract void Patrol();
    protected abstract void WaitPatrol();
}
