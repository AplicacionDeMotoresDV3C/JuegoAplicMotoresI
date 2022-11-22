using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPatrol : Enemy
{
    [SerializeField] protected Transform[] _wayPoints;
    [SerializeField] protected float _wayPointMinDistance;
    [SerializeField] protected float _waitTime;
    protected float _waitTimer;
    protected int _wayPointID = 0;
    protected bool _isWaiting;

    protected abstract void Patrol();
    protected abstract void WaitPatrol();

    protected void NextWayPoint()
    {
        _wayPointID++;

        if (_wayPointID == _wayPoints.Length)
            _wayPointID = 0;
    }
}
